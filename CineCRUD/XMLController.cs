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
        private DataTable dtDados;
        #endregion

        public DataTable GetDataTable()
        {
            return dtDados;
        }
        public XMLController() {
            InicializarDataTable();
        }

        private void InicializarDataTable()
        {
            dtDados = new DataTable();
            dtDados.Columns.Add("Titulo");
            dtDados.Columns.Add("Diretor");
            dtDados.Columns.Add("Genero");
            dtDados.Columns.Add("Lancamento");
            dtDados.Columns.Add("Duracao");
            dtDados.Columns.Add("Avaliacao");
        }

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
    
        public void adicionarFilme(string titulo, string diretor, string genero, string lancamento, string duracao, string avaliacao)
        {
            if (dtDados.Rows.Count == 0) {
                InicializarDataTable();
            }
            DataRow novalinha = dtDados.NewRow();
            novalinha["Titulo"] = titulo;
            novalinha["Diretor"] = diretor;
            novalinha["Genero"] = genero;
            novalinha["Lancamento"] = lancamento;
            novalinha["Duracao"] = duracao;
            novalinha["Avaliacao"] = avaliacao;
            dtDados.Rows.Add(novalinha);
        }
    }
}
