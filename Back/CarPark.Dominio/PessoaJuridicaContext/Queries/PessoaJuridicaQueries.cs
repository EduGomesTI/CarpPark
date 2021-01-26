using System;
using System.Linq.Expressions;
using CarPark.Dominio.PessoaJuridicaContext.Entities;

namespace CarPark.Dominio.PessoaJuridicaContext.Queries
{
    public static class PessoaJuridicaQueries
    {
        public static Expression<Func<PessoaJuridica, bool>> GetCNPJ(string cnpj)
        {
            return x => x.CNPJ == cnpj.Replace(".","").Replace("/","").Replace("-","");
        }

        public static Expression<Func<PessoaJuridica, bool>> GetRazaoSocial(string razaoSocial)
        {
            return x => x.RazaoSocial == razaoSocial;
        }

        public static Expression<Func<PessoaJuridica, bool>> GetNomeFantasia(string nomeFantasia)
        {
            return x => x.NomeFantasia == nomeFantasia;
        }
    }
}