using System.Collections.Generic;
using CarPark.Dominio.PessoaJuridicaContext.Commands;
using CarPark.Dominio.PessoaJuridicaContext.Handlers;
using CarPark.Dominio.Shared.Commands;
using CarPark.Dominio.Shared.Entities;
using CarPark.Testes.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Handlers
{
    [TestClass]
    public class PessoaJuridicaHandlerTest
    {
        private AlterarPessoaJuridicaCommand _alterarCommand;
        private CadastrarPessoaJuridicaCommand _cadastrarCommand;
        private ExcluirPessoaJuridicaCommand _excluirCommand;

        [TestMethod]
        [TestCategory("Dominio.PessoaJuridicaContext.Handlers")]
        public void Dado_um_comando_invalido_deve_interromper_Cadastro()
        {
            _cadastrarCommand = new CadastrarPessoaJuridicaCommand(
                ""
                , ""
                , ""
                , new Endereco(1, "", "", "", "", "", "", "")
                , new List<Telefone>()
                , new List<Email>()
                );
            var handler = new PessoaJuridicaHandler(new FakePessoaJuridicaRepository());
            var result = (GenericCommandResult)handler.Handle(_cadastrarCommand);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Dado_um_comando_valido_deve_Cadastrar_PessoaJuridica()
        {
            _cadastrarCommand = new CadastrarPessoaJuridicaCommand(
                "03.324.292/0001-06"
                , "Microsoft S.A."
                , "Microsoft"
                , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
                , new List<Telefone>() { new Telefone("1145670987") }
                , new List<Email>() { new Email("teste@gmail.com") }
                );
            var handler = new PessoaJuridicaHandler(new FakePessoaJuridicaRepository());
            var result = (GenericCommandResult)handler.Handle(_cadastrarCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Dado_um_comando_invalido_deve_interromper_Alteracao_PessoaJuridica()
        {
            _alterarCommand = new AlterarPessoaJuridicaCommand(
               1
                , ""
                , ""
                , ""
                , new Endereco(1, "", "", "", "", "", "", "")
                , new List<Telefone>()
                , new List<Email>()
                );
            var handler = new PessoaJuridicaHandler(new FakePessoaJuridicaRepository());
            var result = (GenericCommandResult)handler.Handle(_alterarCommand);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Deve_retornar_sucesso_Alterar_PessoaJuridica()
        {
            _alterarCommand = new AlterarPessoaJuridicaCommand(
               1
                , "03.324.292/0001-06"
                , "Microsoft S.A."
                , "Microsoft"
                , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
                , new List<Telefone>() { new Telefone("1145670987") }
                , new List<Email>() { new Email("teste@gmail.com") }
            );
            var handler = new PessoaJuridicaHandler(new FakePessoaJuridicaRepository());
            var result = (GenericCommandResult)handler.Handle(_alterarCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        [TestCategory("Dominio.EnderecoContext.Handlers")]
        public void Deve_retornar_sucesso_Excluir_PessoaJuridica()
        {
            _excluirCommand = new ExcluirPessoaJuridicaCommand(
              1
               , "03.324.292/0001-06"
               , "Microsoft S.A."
               , "Microsoft"
               , new Endereco(1, "Rua X", "123", "", "01234-000", "Devs", "São Paulo", "SP")
               , new List<Telefone>() { new Telefone("1145670987") }
               , new List<Email>() { new Email("teste@gmail.com") }
           );
            var handler = new PessoaJuridicaHandler(new FakePessoaJuridicaRepository());
            var result = (GenericCommandResult)handler.Handle(_excluirCommand);
            Assert.AreEqual(result.Sucesso, true);
        }

    }
}