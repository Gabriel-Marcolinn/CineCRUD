using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineCRUD.Tests.Testes
{
    [TestClass]
    public class CineCRUDIntegrationTests
    {
        [TestMethod]
        public void SalvarXML_DeveSalvarArquivoCorretamente()
        {
            XMLController controle = new XMLController();
            string titulo = "Filme Teste";
            string diretor = "Diretor Teste";
            string genero = "Ação";
            string lancamento = "2023";
            string duracao = "120";
            string avaliacao = "8.5";

            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            string caminhoArquivo = Path.Combine(Path.GetTempPath(), "filmesTeste.xml");

            controle.salvarXML(caminhoArquivo);

            Assert.IsTrue(System.IO.File.Exists(caminhoArquivo));
        }

        [TestMethod]
        public void CarregarXML_DeveCarregarFilmesCorretamente()
        {
            XMLController controle = new XMLController();
            string caminhoArquivo = Path.Combine(Path.GetTempPath(), "filmesTeste.xml");
            if (!System.IO.File.Exists(caminhoArquivo))
            {
                controle.adicionarFilme("Filme Teste", "Diretor Teste", "Ação", "2023", "120", "8.5");
                controle.salvarXML(caminhoArquivo);
            }

            DataTable dtDadosCarregados = controle.CarregarXML(caminhoArquivo);

            Assert.IsNotNull(dtDadosCarregados);
            Assert.AreEqual(1, dtDadosCarregados.Rows.Count);
            Assert.AreEqual("Filme Teste", dtDadosCarregados.Rows[0]["Titulo"]);
            Assert.AreEqual("Diretor Teste", dtDadosCarregados.Rows[0]["Diretor"]);
            Assert.AreEqual("Ação", dtDadosCarregados.Rows[0]["Genero"]);
            Assert.AreEqual("2023", dtDadosCarregados.Rows[0]["Lancamento"]);
            Assert.AreEqual("120", dtDadosCarregados.Rows[0]["Duracao"]);
            Assert.AreEqual("8.5", dtDadosCarregados.Rows[0]["Avaliacao"]);
        }
    }
}
