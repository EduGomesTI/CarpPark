using System.Collections.Generic;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.Repositories
{
    public interface IPessoaJuridicaRepository : IRepository<PessoaJuridica>
    {
        PessoaJuridica GetCNPJ(string cnpj);
        PessoaJuridica GetRazaoSocial(string razaoSocial);
        PessoaJuridica GetNomeFantasia(string nomeFantasia);
    }
}