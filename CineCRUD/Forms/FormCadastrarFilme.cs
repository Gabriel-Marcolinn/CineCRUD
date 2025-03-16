using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineCRUD
{
    public partial class FormCadastrarFilme : Form
    {
        #region Variáveis privadas
        private XMLController controle;
        private XMLController tempControle;
        #endregion

        public FormCadastrarFilme(XMLController controle)
        {
            InitializeComponent();
            this.controle = controle;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Variáveis
            string titulo = inputTitulo.Text.ToString();
            string diretor = inputDiretor.Text.ToString();
            string genero = inputGenero.Text.ToString();
            string stringLancamento = inputLancamento.Text.ToString();
            string stringDuracao = inputDuracao.Text.ToString();
            string stringAvaliacao = inputAvaliacao.Text.ToString();
            #endregion

            tempControle = new XMLController();
            tempControle.adicionarFilme(titulo,diretor,genero,stringLancamento,stringDuracao,stringAvaliacao);

            string mensagemErro;
            if (!tempControle.validaCampos(out mensagemErro))
            {
                MessageBox.Show(mensagemErro, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                controle.adicionarFilme(titulo, diretor, genero, stringLancamento, stringDuracao, stringAvaliacao);
                this.Close();
            }
        }

        private void FormCadastrarFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempControle?.Dispose();
            tempControle = null;
        }

        #region Validações de digitação do usuário nos campos de entrada
        private void inputDuracao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void inputLancamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Validação feita para poder usar o numericUpDown com uma casa decimal, sem problema se o usuário usar vírgula ao invés de ponto na digitação
        private void inputAvaliacao_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }
        }
        #endregion
    }
}