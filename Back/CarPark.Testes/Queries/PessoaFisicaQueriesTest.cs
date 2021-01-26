using System;
using System.Collections.Generic;
using System.Linq;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaFisicaContext.Queries;
using CarPark.Dominio.Shared.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarPark.Testes.Queries
{
    [TestClass]
    public class PessoaFisicaQueriesTest
    {
        private List<Endereco> _enderecos;
        private List<string> _nomes;
        private List<string> _cpfs;  
        private List<Email> _emails;
        private List<Telefone> _telefones;
        private List<DateTime> _datas;
        private List<string> _rgs;
        private List<PessoaFisica> _pessoas;

        public PessoaFisicaQueriesTest()
        {
            _enderecos = new List<Endereco>();
            _enderecos.Add(new Endereco(1, "Rua X", "10", "", "12345-000", "Centro", "Rio", "RJ"));
            _enderecos.Add(new Endereco(2, "Rua Y", "30", "", "67890-000", "Leste", "Brás", "SP"));
            _enderecos.Add(new Endereco(3, "Rua Z", "40", "", "12345-010", "Oeste", "Blumenau", "SC"));

            _nomes = new List<string>();
            _nomes.Add("Bruce Wayne");
            _nomes.Add("Clark Kent");
            _nomes.Add("Diana Prince");

            _cpfs = new List<string>();
            _cpfs.Add("768.034.210-58");
            _cpfs.Add("129.183.690-04");
            _cpfs.Add("654.768.950-60");

            _emails = new List<Email>();
            _emails.Add(new Email("teste1@gmail.com"));
            _emails.Add(new Email("teste2@gmail.com"));
            _emails.Add(new Email("teste3@gmail.com"));

            _telefones = new List<Telefone>();
            _telefones.Add(new Telefone("11983005734"));
            _telefones.Add(new Telefone("19983005734"));
            _telefones.Add(new Telefone("51983005734"));

            _datas = new List<DateTime>();
            _datas.Add(DateTime.Now.AddYears(-19));
            _datas.Add(DateTime.Now.AddYears(-20));
            _datas.Add(DateTime.Now.AddYears(-21));

            _rgs = new List<string>();
            _rgs.Add("14.150.508-4");
            _rgs.Add("42.325.591-5");
            _rgs.Add("35.139.338-9");

            _pessoas = new List<PessoaFisica>();
            _pessoas.Add(new PessoaFisica(1, _enderecos[0], _telefones, _emails, _cpfs[0], _nomes[0], "M", _datas[0], _rgs[0]));
            _pessoas.Add(new PessoaFisica(2, _enderecos[1], _telefones, _emails, _cpfs[1], _nomes[1], "M", _datas[1], _rgs[1]));
            _pessoas.Add(new PessoaFisica(3, _enderecos[2], _telefones, _emails, _cpfs[2], _nomes[2], "M", _datas[2], _rgs[2]));
        }

        [TestMethod]
        [TestCategory("Domain.PessoaFisicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pelo_CPF()
        {
            var result = _pessoas.AsQueryable().Where(PessoaFisicaQueries.GetCPF(_cpfs[1]));
            Assert.AreEqual("Clark Kent", result.ToArray()[0].Nome);
        }
        
        [TestMethod]
        [TestCategory("Domain.PessoaFisicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pelo_Nome()
        {
            var result = _pessoas.AsQueryable().Where(PessoaFisicaQueries.GetNome(_nomes[0]));
            Assert.AreEqual(1, result.Count());
        }
        
        [TestMethod]
        [TestCategory("Domain.PessoaFisicaContext.Queries")]
        public void Dada_a_consulta_deve_retornar_cliente_pelo_RG()
        {
            var result = _pessoas.AsQueryable().Where(PessoaFisicaQueries.GetRG(_rgs[2]));
            Assert.AreEqual(1, result.Count());
        }
    }
}