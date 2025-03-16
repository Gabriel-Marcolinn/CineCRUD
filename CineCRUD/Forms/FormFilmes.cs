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
    public partial class FormFilmes : Form
    {
        #region Variáveis privadas
        private XMLController controle = new XMLController();
        private bool bAlterado = false;
        private bool bSalvo;
        private string sCaminhoArquivo = "";
        #endregion

        public FormFilmes()
        {
            InitializeComponent();
            listaFilmes.DataSource = controle.GetDataTable();
        }

        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(abreArqDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable listaDados = controle.CarregarXML(abreArqDialog.FileName);
                listaFilmes.DataSource = listaDados;

                bAlterado = false;
                sCaminhoArquivo = abreArqDialog.FileName;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarFilme cadastraFilme = new FormCadastrarFilme(controle);
            cadastraFilme.ShowDialog();

            // Atualiza a lista após fechar o cadastro
            listaFilmes.DataSource = controle.GetDataTable();

            if (controle.GetDataTable().Rows.Count > 0)
            {
                bAlterado = true;
            }
        }

        private void listaFilmes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bAlterado = true;
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controle.GetDataTable().Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para salvar.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            sCaminhoArquivo = Salvar(sCaminhoArquivo.ToString());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFilmes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bAlterado == true)
            {
                DialogResult resposta = MessageBox.Show("O Arquivo foi alterado. Deseja salvar as alterações feitas?", "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    Salvar(sCaminhoArquivo);
                    if (bSalvo == false)
                    {
                        e.Cancel = true;
                    }

                }
                else if (resposta == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        //Função própria que valida se o arquivo já existe (foi carregado) ou se precisa do salvaArquivoDialog, para criar um novo
        private string Salvar(string sCaminhoArquivo)
        {
            bSalvo = false;
            string mensagemErro;
            if (!controle.validaCampos(out mensagemErro))
            {
                MessageBox.Show(mensagemErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sCaminhoArquivo == "" && salvaArquivoDialog.ShowDialog() == DialogResult.OK)
                {
                    sCaminhoArquivo = salvaArquivoDialog.FileName;
                }
                controle.salvarXML(sCaminhoArquivo);
                bAlterado = false;
                bSalvo = true;
            }
            return sCaminhoArquivo;
        }
    }
}
