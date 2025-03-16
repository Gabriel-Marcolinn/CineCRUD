using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace CineCRUD.Tests
{
    [TestClass]
    public class CineCRUDTests
    {
        [TestMethod]
        public void inicializarDataTableDeveCriarColunasCorretamente()
        {
            XMLController controle = new XMLController();
            DataTable dtDados = controle.GetDataTable();

            Assert.IsNotNull(dtDados);
            Assert.AreEqual(6, dtDados.Columns.Count);

            List<string> colunasEsperadas = new List<string> { "Titulo", "Diretor", "Genero", "Lancamento", "Duracao", "Avaliacao" };
            List<string> colunasReais = new List<string>();
            foreach (DataColumn coluna in dtDados.Columns)
            {
                colunasReais.Add(coluna.ColumnName);
            }

            CollectionAssert.AreEqual(colunasEsperadas, colunasReais);
        }

        [TestMethod]
        public void adicionarFilmeDeveAdicionarOFilmeNaLista()
        {
            XMLController controle = new XMLController();

            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string duracao = "180";
            string avaliacao = "5";

            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            DataTable dtDados = controle.GetDataTable();

            Assert.AreEqual(1, dtDados.Rows.Count);
            Assert.AreEqual(titulo, dtDados.Rows[0]["Titulo"]);
            Assert.AreEqual(diretor, dtDados.Rows[0]["Diretor"]);
            Assert.AreEqual(genero, dtDados.Rows[0]["Genero"]);
            Assert.AreEqual(lancamento, dtDados.Rows[0]["Lancamento"]);
            Assert.AreEqual(duracao, dtDados.Rows[0]["Duracao"]);
            Assert.AreEqual(avaliacao, dtDados.Rows[0]["Avaliacao"]);
        }
        
        [TestMethod]    
        public void validaCamposDeveRetornarFalsoSeCamposEstaoEmBranco()
        {
            XMLController controle = new XMLController();

            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "";
            string lancamento = "2025";
            string duracao = "180";
            string avaliacao = "5";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);

            Assert.IsFalse(controle.validaCampos());
        }

        [TestMethod]
        public void validaCamposDeveRetornarFalsoSeOAnoForInvalido()
        {
            //Ano maior que o atual
            XMLController controle = new XMLController();
            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = DateTime.Now.Year+1.ToString();
            string duracao = "180";
            string avaliacao = "5";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            
            Assert.IsFalse(controle.validaCampos());

            //Ano anterior ao lançamento do primeiro filme do mundo
            string lancamento2 = "1850";
            controle.adicionarFilme(titulo, diretor, genero, lancamento2, duracao, avaliacao);

            Assert.IsFalse(controle.validaCampos());
        }
    }
}
