using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineCRUD
{
    public class XMLController
    {
        #region Variáveis Privadas
        private DataTable dtDados = new DataTable();

        #endregion

        public void InicializarForm()
        {
            FormFilmes form = new FormFilmes();
        }

        public DataTable CarregarXML(string arqXML)
        {
            try
            {
                if (string.IsNullOrEmpty(arqXML) || !System.IO.File.Exists(arqXML))
                {
                    MessageBox.Show("O arquivo XML não foi encontrado ou está vazio.");
                    return null;
                }

                dtDados.Clear();
                    DataSet tempDataSet = new DataSet();
                    tempDataSet.ReadXml(arqXML);
                    dtDados = tempDataSet.Tables[0].Copy();

                    return dtDados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar XML: " + ex.Message);
                return null;
            }
        }
    }
}
