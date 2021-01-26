using System;
using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Commands;
using CarPark.Dominio.PessoaFisicaContext.Handlers;
using CarPark.Dominio.Shared.Commands;
using CarPark.Dominio.Shared.Entities;
using CarPark.Testes.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Handlers
{
    [TestClass]
    public class PessoaFisicaHandlerTest
    {
        private AlterarPessoaFisicaCommand _alterarCommand;
        private CadastrarPessoaFisicaCommand _cadastrarCommand;
        private ExcluirPessoaFisicaCommand _excluirCommand;

        [TestMethod]
        [TestCategory("Dominio.PessoaFisicaContext.Handlers")]
        public void Dado_um_comando_invalido_deve_interromper_Cadastro()
        {
            _cadastrarCommand = new CadastrarPessoaFisicaCommand(
                "",
                ""
                , ""
                , DateTime.Now
                , ""
                , new Endereco(1, "", "", "", "", "", "", "")
                , new List<Telefone>()
                , new List<Email>()
                );
            var handler = new PessoaFisicaHandler(new FakePessoaFisicaRepository());
            var result = (GenericCommandResult)handler.Handle(_cadastrarCommand);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Dado_um_comando_valido_deve_Cadastrar_PessoaFisica()
        {
            _cadastrarCommand = new CadastrarPessoaFisicaCommand(
                "994.570.630-66",
                "Eduardo"
                , ""
                , DateTime.Now.AddYears(-20)
                , "26.906.683-4"
                , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
                , new List<Telefone>() { new Telefone("1145670987") }
                , new List<Email>() { new Email("teste@gmail.com") }
                );
            var handler = new PessoaFisicaHandler(new FakePessoaFisicaRepository());
            var result = (GenericCommandResult)handler.Handle(_cadastrarCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Dado_um_comando_invalido_deve_interromper_Alteracao_PessoaFisica()
        {
            _alterarCommand = new AlterarPessoaFisicaCommand(
                1
                , ""
                , ""
                , ""
                , DateTime.Now
                , ""
                , new Endereco(1, "", "", "", "", "", "", "")
                , new List<Telefone>()
                , new List<Email>()
                );
            var handler = new PessoaFisicaHandler(new FakePessoaFisicaRepository());
            var result = (GenericCommandResult)handler.Handle(_alterarCommand);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Deve_retornar_sucesso_Alterar_PessoaFisica()
        {
            _alterarCommand = new AlterarPessoaFisicaCommand(
                1
                , "994.570.630-66"
                , "Eduardo"
                , ""
                , DateTime.Now.AddYears(-20)
                , "26.906.683-4"
                , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
                , new List<Telefone>() { new Telefone("1145670987") }
                , new List<Email>() { new Email("teste@gmail.com") }
                );
            var handler = new PessoaFisicaHandler(new FakePessoaFisicaRepository());
            var result = (GenericCommandResult)handler.Handle(_alterarCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Deve_retornar_sucesso_Excluir_PessoaFisica()
        {
            _excluirCommand = new ExcluirPessoaFisicaCommand(
                1
                , "994.570.630-66"
                , "Eduardo"
                , "M"
                , DateTime.Now
                , "26.906.683-4"
                , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
                , new List<Telefone>() { new Telefone("1145670987") }
                , new List<Email>() { new Email("teste@gmail.com") }
                );
            var handler = new PessoaFisicaHandler(new FakePessoaFisicaRepository());
            var result = (GenericCommandResult)handler.Handle(_excluirCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

    }
}