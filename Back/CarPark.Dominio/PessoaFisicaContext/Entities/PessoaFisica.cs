using System;
using System.Collections.Generic;
using CarPark.Dominio.Shared.Entities;
using Flunt.Br.Extensions;
using Flunt.Validations;

namespace CarPark.Dominio.PessoaFisicaContext.Entities
{
    public class PessoaFisica : Pessoa
    {
        public int PessoaFisicaId { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Rg { get; private set; }

        protected PessoaFisica() { }

        public PessoaFisica(int pessoaFisicaId, Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails, string cpf, string nome, string sexo, DateTime dataNascimento, string rg) : base(endereco, telefones, emails)
        {
            PessoaFisicaId = pessoaFisicaId;
            AlterarCPF(cpf);
            AlterarNome(nome);
            AlterarSexo(sexo);
            AlterarDataNascimento(dataNascimento);
            AlterarRG(rg);
        }

        public PessoaFisica(Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails, string cpf, string nome, string sexo, DateTime dataNascimento, string rg) : base(endereco, telefones, emails)
        {
            AlterarCPF(cpf);
            AlterarNome(nome);
            AlterarSexo(sexo);
            AlterarDataNascimento(dataNascimento);
            AlterarRG(rg);
        }

        public bool AlterarNome(string nome)
        {
            AddNotifications(
                new Contract()
                .IsBetween(nome.Length, 3, 40, "Nome", "O Nome deve ter entre 3 e 40 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Nome = nome;
            return true;
        }

        public bool AlterarDataNascimento(DateTime data)
        {
            //Verifica se a pessoa tem mais que 18 e menos que 100 anos
            AddNotifications(
                new Contract()
                .IsBetween(data, DateTime.Now.AddYears(-100), DateTime.Now.AddYears(-18), "Data", "Data de Nascimento inválida.")
            );

            if (Notifications.Count != 0)
                return false;

            DataNascimento = data;
            return true;
        }

        public bool AlterarSexo(string sexo)
        {
            AddNotifications(
                new Contract()
                .HasLen(sexo, 1, "Sexo", "Sexo não informado.")
            );

            if (Notifications.Count != 0)
                return false;

            Sexo = sexo;
            return true;
        }

        public bool AlterarRG(string rg)
        {
            //Como não existe uma padronização em ralação a validação de RG será somente verificado se o campo não está vazio.
            AddNotifications(
                new Contract()
                .HasMinLen(rg, 1, "Documento", "RG não informado. Por favor, verifique.")
            );

            if (Notifications.Count != 0)
                return false;

            Rg = rg.Replace(".", "").Replace("-", "");
            return true;
        }

        public bool AlterarCPF(string cpf)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsCpf(cpf, "CPF", "CPF inválido. Por favor, verifique.")
            );

            if (Notifications.Count != 0)
                return false;

            CPF = cpf.Replace("-", "").Replace(".", "");
            return true;
        }
    }
}