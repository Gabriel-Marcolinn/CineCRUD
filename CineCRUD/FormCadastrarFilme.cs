using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineCRUD
{
    public partial class FormCadastrarFilme : Form
    {
        #region Variáveis privadas
        private XMLController controle;
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
            #region Validações
            if (inputTitulo.Text.ToString() == "" || inputDiretor.Text.ToString() == "" || inputGenero.Text.ToString() == "" || inputLancamento.Text.ToString() == "" || inputDuracao.Text.ToString() == "" || inputAvaliacao.Text.ToString() == "")
            {
                MessageBox.Show("É necessário preencher todos os campos para poder cadastrar um novo filme!", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int lancamento = Convert.ToInt32(inputLancamento.Text);
                    int duracao = Convert.ToInt32(inputDuracao.Text);
                    int avaliacao = Convert.ToInt32(inputAvaliacao.Text);

                    if ((lancamento < 1900 || lancamento > DateTime.Now.Year) || (duracao <= 0 || duracao > 10000) || (avaliacao < 1 || avaliacao > 10))
                    {
                        throw new ArgumentException("Os dados informados de lançamento, ano ou duração são inválidos!");
                    }

                    #region Salva dados
                        string titulo = inputTitulo.Text.ToString();
                        string diretor = inputDiretor.Text.ToString();
                        string genero = inputGenero.Text.ToString();
                        string stringLancamento = inputLancamento.Text.ToString();
                        string stringDuracao = inputDuracao.Text.ToString();
                        string stringAvaliacao = inputAvaliacao.Text.ToString();

                        controle.adicionarFilme(titulo, diretor, genero, stringLancamento, stringDuracao, stringAvaliacao);

                        this.Close();
                    #endregion
                }
                catch (FormatException)
                {
                    MessageBox.Show("Insira números válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            #endregion
        }

        #region Impedindo o usuário de digitar letras nos textboxes de números
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

        private void inputAvaliacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
