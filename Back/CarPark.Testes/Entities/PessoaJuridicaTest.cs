using System.Collections.Generic;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Entities
{
    [TestClass]
    public class PessoaJuridicaTest
    {
        private static List<Telefone> _telefones = new List<Telefone>()
        {
            new Telefone("11987651234")
            , new Telefone("11976544567")
            , new Telefone("1127129845")
        };
        private static List<Email> _emails = new List<Email>()
        {
            new Email("teste@gmail.com")
            , new Email("testes@hotmail.com")
            , new Email("teste@microsoft.com.br")
        };
        private static Endereco _endereco = new Endereco(
            1
            , "Av Paulista"
            , "1215"
            , "Apto 34"
            , "03455-010"
            , "Bela Vista"
            , "São Paulo"
            , "SP");

        private PessoaJuridica _pj = new PessoaJuridica(
            1
            , _endereco
            , _telefones
            , _emails
            , "09.821.410/0001-78"
            , "Rift Sistemas Ltda."
            , "Rift Sistemas"
        );

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_sucesso_quando_pj_estiver_certo()
        {
            Assert.IsTrue(_pj.Valid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_RazaoSocial_tiver_menos_que_3_chars()
        {
            _pj.AlterarRazaoSocial("Ri");
            Assert.IsTrue(_pj.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_RazaoSocial_tiver_mais_que_100_chars()
        {
            _pj.AlterarRazaoSocial("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras bibendum non nisl et faucibus. Phasellus venenatis diam non sodales mollis.");
            Assert.IsTrue(_pj.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_NomeFantasia_tiver_menos_que_3_chars()
        {
            _pj.AlterarNomeFantasia("Ri");
            Assert.IsTrue(_pj.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_NomeFantasia_tiver_mais_que_100_chars()
        {
            _pj.AlterarNomeFantasia("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras bibendum non nisl et faucibus. Phasellus venenatis diam non sodales mollis.");
            Assert.IsTrue(_pj.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_cnpj_estiver_errado()
        {
            _pj.AlterarCNPJ("41.234.789/0001-12");
            Assert.IsTrue(_pj.Invalid);
        }

    }
}