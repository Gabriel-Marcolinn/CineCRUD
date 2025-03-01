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
        public FormCadastrarFilme()
        {
            InitializeComponent();
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
                MessageBox.Show("Atenção!\nÉ necessário preencher todos os campos para poder cadastrar um novo filme!");
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
                        throw new ArgumentException("Atenção!\nOs dados informados de lançamento, ano ou duração são inválidos!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Atenção! Insira números válido.");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
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
