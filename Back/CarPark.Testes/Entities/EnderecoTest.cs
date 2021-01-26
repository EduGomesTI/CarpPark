using CarPark.Dominio.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Entities
{
    [TestClass]
    public class EnderecoTest
    {
        private Endereco _endereco = new Endereco(
            1
            , "Av Paulista"
            , "1215"
            , "Apto 34"
            , "03455-010"
            , "Bela Vista"
            , "São Paulo"
            , "SP");

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_logradouro_tiver_menos_que_3_chars()
        {
            _endereco.AlterarLogradouro("Av");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_logradouro_tiver_mais_que_60_chars()
        {
            _endereco.AlterarLogradouro("Avenida Paulista, 1215 Apto 34 03455-010 Bela Vista São Paulo SP");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_numero_estiver_vazio()
        {
            _endereco.AlterarNumero(string.Empty);
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_numero_tiver_mais_que_5_chars()
        {
            _endereco.AlterarNumero("A123456");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_complemento_tiver_mais_que_10_chars()
        {
            _endereco.AlterarComplemento("Sala 10 Conjunto 45");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_sucesso_quando_complemento_estiver_vazio()
        {
            _endereco.AlterarComplemento(string.Empty);
            Assert.IsTrue(_endereco.Valid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_cep_for_invalido()
        {
            _endereco.AlterarCEP("5678-000");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_bairro_tiver_menos_que_3_chars()
        {
            _endereco.AlterarBairro("Ba");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_bairro_tiver_mais_que_20_chars()
        {
            _endereco.AlterarBairro("Bela Vista de fumaça cinza e escura");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_cidade_tiver_menos_que_3_chars()
        {
            _endereco.AlterarBairro("Sa");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_cidade_tiver_mais_que_15_chars()
        {
            _endereco.AlterarBairro("São Paulo do Estado de São Paulo");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_erro_quando_estado_nao_tiver_2_chars()
        {
            _endereco.AlterarEstado("SPC");
            Assert.IsTrue(_endereco.Invalid);
        }

        [TestMethod]
        [TestCategory("Dominio.Entities")]
        public void Deve_retornar_sucesso_quando_endereco_estiver_correto()
        {
            Assert.IsTrue(_endereco.Valid);
        }
    }
}