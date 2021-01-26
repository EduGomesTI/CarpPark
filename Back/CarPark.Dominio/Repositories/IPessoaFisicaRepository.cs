using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.Repositories
{
    public interface IPessoaFisicaRepository : IRepository<PessoaFisica>
    {
        PessoaFisica GetCPF(string cpf);
        PessoaFisica GetNome(string nome);
        PessoaFisica GetRG(string rg);
    }
}