using System;
using System.Linq.Expressions;
using CarPark.Dominio.PessoaFisicaContext.Entities;

namespace CarPark.Dominio.PessoaFisicaContext.Queries
{
    public static class PessoaFisicaQueries
    {
        public static Expression<Func<PessoaFisica, bool>> GetCPF(string cpf)
        {
            
            return x => x.CPF == cpf.Replace(".","").Replace("-","");      
        }

        public static Expression<Func<PessoaFisica, bool>> GetNome(string nome) 
        {
            return x => x.Nome == nome;
        }

        public static Expression<Func<PessoaFisica, bool>> GetRG(string rg) 
        {
            return x => x.Rg == rg.Replace(".","").Replace("-","");
        }
    }
}