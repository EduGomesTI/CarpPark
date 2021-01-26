using System.Collections.Generic;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CarPark.Dominio.PessoaJuridicaContext.Queries;

namespace CarPark.Testes.Queries
{
    [TestClass]
    public class PessoaJuridicaQueriesTest
    {
        private List<Endereco> _enderecos;
        private List<string> _cnpjs;  
        private List<Email> _emails;
        private List<Telefone> _telefones;
        private List<PessoaJuridica> _Pjs;

        public PessoaJuridicaQueriesTest()
        {
            _enderecos = new List<Endereco>();
            _enderecos.Add(new Endereco(1, "Rua X", "10", "", "12345-000", "Centro", "Rio", "RJ"));
            _enderecos.Add(new Endereco(2, "Rua Y", "30", "", "67890-000", "Leste", "Brás", "SP"));
            _enderecos.Add(new Endereco(3, "Rua Z", "40", "", "12345-010", "Oeste", "Blumenau", "SC"));

            _cnpjs = new List<string>();
            _cnpjs.Add("41.262.031/0001-06");
            _cnpjs.Add("46.780.290/0001-34");
            _cnpjs.Add("32.066.775/0001-56");

            _emails = new List<Email>();
            _emails.Add(new Email("teste1@gmail.com"));
            _emails.Add(new Email("teste2@gmail.com"));
            _emails.Add(new Email("teste3@gmail.com"));

            _telefones = new List<Telefone>();
            _telefones.Add(new Telefone("11983005734"));
            _telefones.Add(new Telefone("19983005734"));
            _telefones.Add(new Telefone("51983005734"));

            _Pjs = new List<PessoaJuridica>();
            _Pjs.Add(new PessoaJuridica(1, _enderecos[0], _telefones, _emails, _cnpjs[0], "Microsoft S.A.", "Microsoft"));
            _Pjs.Add(new PessoaJuridica(2, _enderecos[1], _telefones, _emails, _cnpjs[1], "Apple Inc.", "Apple"));
            _Pjs.Add(new PessoaJuridica(3, _enderecos[2], _telefones, _emails, _cnpjs[2], "Google Inc.", "Google"));

        }

        [TestMethod]
        [TestCategory("Domain.PessoaJuridicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pelo_CNPJ()
        {
            var result = _Pjs.AsQueryable().Where(PessoaJuridicaQueries.GetCNPJ(_cnpjs[0]));
            var count = result.Count();
            var cnpj = result.ToArray()[0].CNPJ;
            Assert.AreEqual(1, result.Count());
        }
        
        [TestMethod]
        [TestCategory("Domain.PessoaJuridicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pela_RazaoSocial()
        {
            var result = _Pjs.AsQueryable().Where(PessoaJuridicaQueries.GetRazaoSocial("Apple Inc."));
            Assert.AreEqual(1, result.Count());
        }
        
        [TestMethod]
        [TestCategory("Domain.PessoaJuridicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pelo_NomeFantasia()
        {
            var result = _Pjs.AsQueryable().Where(PessoaJuridicaQueries.GetNomeFantasia("Google"));
            var nome = result.ToArray()[0].NomeFantasia;
            Assert.AreEqual(1, result.Count());
        }
    }
}