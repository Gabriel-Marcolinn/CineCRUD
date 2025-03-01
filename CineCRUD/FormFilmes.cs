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
        #endregion

        public FormFilmes()
        {
            InitializeComponent();
        }

        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(abreArqDialog.ShowDialog() == DialogResult.OK)
            {
                listaFilmes.DataSource = controle.CarregarXML(abreArqDialog.FileName);
            }
        }
    }
}
