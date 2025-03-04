﻿using System;
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
        private bool bAlterado;
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

                if (controle.GetDataTable().Rows.Count > 0)
                {
                    bAlterado = true;
                }
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarFilme cadastraFilme = new FormCadastrarFilme(controle);
            cadastraFilme.ShowDialog();

            // Atualiza a lista após fechar o cadastro
            listaFilmes.DataSource = null;
            listaFilmes.DataSource = controle.GetDataTable();

            if (controle.GetDataTable().Rows.Count > 0)
            {
                bAlterado = true;
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja salvar as alterações feitas?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (salvaArquivoDialog.ShowDialog() == DialogResult.OK)
                {
                    controle.salvarXML(salvaArquivoDialog.FileName);
                }
            }
        }

        private void listaFilmes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bAlterado = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
