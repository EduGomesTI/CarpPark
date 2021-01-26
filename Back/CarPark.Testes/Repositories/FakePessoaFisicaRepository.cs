using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.Repositories;

namespace CarPark.Testes.Repositories
{
    public class FakePessoaFisicaRepository : IPessoaFisicaRepository
    {
        public void Alterar(PessoaFisica entity)
        {

        }

        public void Cadastrar(PessoaFisica entity)
        {
         
        }

        public void Excluir(int id)
        {
  
        }
        public int NovoId()
        {
            return 1;
        }

        PessoaFisica IPessoaFisicaRepository.GetCPF(string cpf)
        {
            throw new System.NotImplementedException();
        }

        PessoaFisica IPessoaFisicaRepository.GetNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        PessoaFisica IPessoaFisicaRepository.GetRG(string rg)
        {
            throw new System.NotImplementedException();
        }
    }
}