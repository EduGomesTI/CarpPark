using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.Repositories;

namespace CarPark.Testes.Repositories
{
    public class FakePessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        public void Alterar(PessoaJuridica entity)
        {

        }

        public void Cadastrar(PessoaJuridica entity)
        {

        }

        public void Excluir(int id)
        {

        }

        public int NovoId()
        {
            return 1;
        }

        PessoaJuridica IPessoaJuridicaRepository.GetCNPJ(string cnpj)
        {
            throw new System.NotImplementedException();
        }

        PessoaJuridica IPessoaJuridicaRepository.GetNomeFantasia(string nomeFantasia)
        {
            throw new System.NotImplementedException();
        }

        PessoaJuridica IPessoaJuridicaRepository.GetRazaoSocial(string razaoSocial)
        {
            throw new System.NotImplementedException();
        }
    }
}