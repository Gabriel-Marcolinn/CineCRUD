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

            string mensagemErro;
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("Existem um ou mais campos obrigatórios em branco!", mensagemErro);
        }

        [TestMethod]
        public void validaCamposDeveRetornarFalsoSeAnoForInvalido()
        {
            XMLController controle = new XMLController();
            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string duracao = "180";
            string avaliacao = "5";
            string mensagemErro;

            //Ano maior que o atual
            string lancamento = DateTime.Now.Year + 1.ToString();
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("O ano informado é inválido!", mensagemErro);

            //Ano anterior ao lançamento do primeiro filme do mundo
            lancamento = "1850";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("O ano informado é inválido!", mensagemErro);
        }

        [TestMethod]
        public void validaCamposDeveRetornarFalsoSeDuracaoForInvalida()
        {
            XMLController controle = new XMLController();

            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string avaliacao = "5";
            string mensagemErro;

            //Duração zero
            string duracao = "0";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("A duração em minutos informada é inválida!", mensagemErro);

            //Duração maior que 51420 minutos, tempo do maior filme do mundo
            duracao = "51421";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("A duração em minutos informada é inválida!", mensagemErro);
        }

        [TestMethod]
        public void validaCamposDeveRetornarFalsoSeAvaliacaoForInvalida()
        {
            XMLController controle = new XMLController();

            
            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string duracao = "180";
            string mensagemErro;

            //Avaliacao 0
            string avaliacao = "0";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("A Avaliação informada é inválida!", mensagemErro);

            //Avaliacao > 10
            avaliacao = "10.1";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("A Avaliação informada é inválida!", mensagemErro);
        }

        [TestMethod]
        public void validaCamposDeveRetornarVerdadeoiroSeAvaliacaoTiverPontoOuVirgulaDeSeparador()
        {
            XMLController controle = new XMLController();


            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string duracao = "180";
            string mensagemErro;

            //Avaliacao com virgula
            string avaliacao = "5,5";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsTrue(controle.validaCampos(out mensagemErro));

            //Avaliacao com Ponto
            avaliacao = "5.5";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsTrue(controle.validaCampos(out mensagemErro));
        }

        [TestMethod]
        public void validaCamposDeveDarErroAoConverterLetrasParaNumeros()
        {
            XMLController controle = new XMLController();


            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string duracao = "180";
            string mensagemErro;

            //Campo numérico com letra
            string avaliacao = "a";
            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            Assert.IsFalse(controle.validaCampos(out mensagemErro));
            Assert.AreEqual("Insira números válidos nos campos de Lançamento, Duração e Avaliação.", mensagemErro);
        }

        [TestMethod]
        public void funcaoDisposeDeveDeixarODataTableNulo()
        {
            XMLController controle = new XMLController();

            string titulo = "Filme Teste";
            string diretor = "Diretor teste";
            string genero = "Suspense";
            string lancamento = "2025";
            string duracao = "180";
            string avaliacao = "10";

            controle.adicionarFilme(titulo, diretor, genero, lancamento, duracao, avaliacao);
            controle.Dispose();
            Assert.IsNull(controle.GetDataTable());
        }
    }
}
