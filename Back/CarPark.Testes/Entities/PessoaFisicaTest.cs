using System;
using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Entities
{
    [TestClass]
    public class PessoaFisicaTest
    {
        private static Endereco _endereco = new Endereco(
            1
            , "Av Paulista"
            , "1215"
            , "Apto 34"
            , "03455-010"
            , "Bela Vista"
            , "São Paulo"
            , "SP");

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

        private PessoaFisica _pessoa = new PessoaFisica(
                1
                , _endereco
                , _telefones
                , _emails
                , "435.182.030-61"
                , "Eduardo Gomes"
                , "M"
                , new DateTime(1976, 12, 10)
                , "32.596.499-3"
            );

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_nome_estiver_vazio()
        {
            _pessoa.AlterarNome("");
            Assert.IsTrue(_pessoa.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_nome_tiver_mais_que_60_caracteres()
        {
            _pessoa.AlterarNome("Eduardo Lopes Gomes da Silva Sauro Borges Brown Black White");
            Assert.IsTrue(_pessoa.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_cpf_estiver_errado()
        {
            _pessoa.AlterarCPF("123.456.789-11");
            Assert.IsTrue(_pessoa.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_sexo_estiver_vazio()
        {
            _pessoa.AlterarSexo("");
            Assert.IsTrue(_pessoa.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_rg_estiver_vazio()
        {
            _pessoa.AlterarRG("");
            Assert.IsTrue(_pessoa.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_sucesso_quando_pessoaFisica_estiver_certo()
        {
            Assert.IsTrue(_pessoa.Valid);
        }
    }
}