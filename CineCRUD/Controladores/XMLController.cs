using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        public DataTable CarregarXML(string arqXML)
        {
            try
            {
                if (string.IsNullOrEmpty(arqXML) || !System.IO.File.Exists(arqXML))
                {
                    MessageBox.Show("O arquivo XML não foi encontrado ou está vazio.", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
                }

                    DataSet tempDataSet = new DataSet();
                    tempDataSet.ReadXml(arqXML);
                    dtDados = tempDataSet.Tables[0].Copy();

                    return dtDados;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Erro ao carregar XML: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro desconhecido: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void salvarXML(string caminhoArquivo)
        {
            if (!caminhoArquivo.EndsWith(".xml"))
            {
                caminhoArquivo += ".xml";
            }
            try
            {
                if (dtDados == null || dtDados.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum dado para salvar", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                XElement raiz = new XElement("Filmes");

                foreach(DataRow row in dtDados.Rows)
                {
                    XElement filme = new XElement("Filme",
                        new XElement("Titulo", row["Titulo".ToString()]),
                        new XElement("Diretor", row["Diretor".ToString()]),
                        new XElement("Genero", row["Genero".ToString()]),
                        new XElement("Lancamento", row["Lancamento".ToString()]),
                        new XElement("Duracao", row["Duracao".ToString()]),
                        new XElement("Avaliacao", row["Avaliacao".ToString()])
                    );
                    raiz.Add(filme);
                }
                //adiciona todos os elementos no arquivo
                doc.Add(raiz);

                doc.Save(caminhoArquivo);

                MessageBox.Show("Arquivo XML salvo com sucesso!", "Atenção!", MessageBoxButtons.OK);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Erro ao salvar XML: Acesso negado. {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar XML: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool validaCampos(out string mensagemErro)
        {
            mensagemErro = "";
            foreach (DataRow row in dtDados.Rows)
            {
                if (string.IsNullOrWhiteSpace(row["Titulo"]?.ToString()) ||
                    string.IsNullOrWhiteSpace(row["Diretor"]?.ToString()) ||
                    string.IsNullOrWhiteSpace(row["Genero"]?.ToString()) ||
                    string.IsNullOrWhiteSpace(row["Lancamento"]?.ToString()) ||
                    string.IsNullOrWhiteSpace(row["Duracao"]?.ToString()) ||
                    string.IsNullOrWhiteSpace(row["Avaliacao"]?.ToString()))
                {
                    mensagemErro ="Existem um ou mais campos obrigatórios em branco!";
                    return false;
                }

                try
                {
                    int lancamento = Convert.ToInt32(row["Lancamento"]);
                    int duracao = Convert.ToInt32(row["Duracao"]);

                    string avaliacaoString = row["Avaliacao"].ToString().Replace(",", ".");
                    double avaliacao = Convert.ToDouble(avaliacaoString);

                    if (lancamento < 1895 || lancamento > DateTime.Now.Year)
                    {
                        throw new ArgumentException("O ano informado é inválido!");
                    }
                    if (duracao <= 0 || duracao > 51420)
                    {
                        throw new ArgumentException("A duração em minutos informada é inválida!");
                    }
                    if (avaliacao < 1.0 || avaliacao > 10.0)
                    {
                        throw new ArgumentException("A Avaliação informada é inválida!");
                    }
                }
                catch (FormatException)
                {
                    mensagemErro = "Insira números válidos nos campos de Lançamento, Duração e Avaliação.";
                    return false;
                }
                catch (ArgumentException ex)
                {
                    mensagemErro = ex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    mensagemErro = "Ocorreu um erro inesperado: " + ex.Message;
                    return false;
                }
            }
            return true;
        }

        public void Dispose()
        {
            if (dtDados != null)
            {
                dtDados.Clear();
                dtDados.Dispose();
                dtDados = null;
            }
        }
    }
}
