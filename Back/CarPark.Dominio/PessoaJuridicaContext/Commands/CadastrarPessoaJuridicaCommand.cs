using System.Collections.Generic;
using CarPark.Dominio.Shared.Entities;
using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.PessoaJuridicaContext.Commands
{
    public class CadastrarPessoaJuridicaCommand: ICommand
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Email> Emails { get; set; }

        public CadastrarPessoaJuridicaCommand() { }

        public CadastrarPessoaJuridicaCommand(string cnpj, string razaoSocial, string nomeFantasia, Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails)
        {
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