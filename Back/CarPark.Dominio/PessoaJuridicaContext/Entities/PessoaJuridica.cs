using System.Collections.Generic;
using CarPark.Dominio.Shared.Entities;
using Flunt.Br.Extensions;
using Flunt.Validations;

namespace CarPark.Dominio.PessoaJuridicaContext.Entities
{
    public class PessoaJuridica : Pessoa
    {
        public int PessoaJuridicaId { get; private set; }
        public string CNPJ { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }

        protected PessoaJuridica() { }
        public PessoaJuridica(int pessoaJuridicaId, Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails, string cnpj, string razaoSocial, string nomeFantasia) : base(endereco, telefones, emails)
        {
            PessoaJuridicaId = pessoaJuridicaId;
            AlterarCNPJ(cnpj);
            AlterarRazaoSocial(razaoSocial);
            AlterarNomeFantasia(nomeFantasia);
        }

        public PessoaJuridica(Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails, string cnpj, string razaoSocial, string nomeFantasia) : base(endereco, telefones, emails)
        {
            AlterarCNPJ(cnpj);
            AlterarRazaoSocial(razaoSocial);
            AlterarNomeFantasia(nomeFantasia);
        }

        public bool AlterarCNPJ(string cnpj)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsCnpj(cnpj, "Documento", "CNPJ inválido. Por favor, verifique.")
            );

            if (Notifications.Count != 0)
                return false;

            CNPJ = cnpj.Replace("/", "").Replace(".", "").Replace("-", "");
            return true;
        }

        public bool AlterarRazaoSocial(string razaoSocial)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(razaoSocial, 3, "Descricao", "Razão Social deve ter entre 3 e 100 caracteres.")
                .HasMaxLen(razaoSocial, 100, "Descricao", "Razão Social deve ter entre 3 e 100 caracteres. ")
            );

            if (Notifications.Count != 0)
                return false;

            RazaoSocial = razaoSocial;
            return true;
        }

        public bool AlterarNomeFantasia(string nomeFantasia)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(nomeFantasia, 3, "Descricao", "Nome Fantasia deve ter entre 3 e 100 caracteres.")
                .HasMaxLen(nomeFantasia, 100, "Descricao", "Nome Fantasia deve ter entre 3 e 100 caracteres. ")
            );

            if (Notifications.Count != 0)
                return false;

            NomeFantasia = nomeFantasia;
            return true;
        }
    }
}