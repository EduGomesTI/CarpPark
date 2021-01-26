using System.Collections.Generic;
using CarPark.Dominio.Shared.Entities;
using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.PessoaJuridicaContext.Commands
{
    public class AlterarPessoaJuridicaCommand : ICommand
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Email> Emails { get; set; }

        public AlterarPessoaJuridicaCommand() { }

        public AlterarPessoaJuridicaCommand(int id, string cnpj, string razaoSocial, string nomeFantasia, Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails)
        {
            Id = id;
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Endereco = endereco;
            Telefones = telefones;
            Emails = emails;
        }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}