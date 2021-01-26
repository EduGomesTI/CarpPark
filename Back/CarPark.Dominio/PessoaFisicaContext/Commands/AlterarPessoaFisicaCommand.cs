using System;
using System.Collections.Generic;
using CarPark.Dominio.Shared.Entities;
using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.PessoaFisicaContext.Commands
{
    public class AlterarPessoaFisicaCommand : ICommand
    {
        public int PessoaFisicaId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Email> Emails { get; set; }

        public AlterarPessoaFisicaCommand()
        {
        }
        public AlterarPessoaFisicaCommand(int pessoaFisicaId, string cpf, string nome, string sexo, DateTime dataNascimento, string rg, Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails)
        {
            PessoaFisicaId = pessoaFisicaId;
            CPF = cpf;
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Rg = rg;
            Endereco = endereco;
            Telefones = telefones;
            Emails = emails;
        }
    }
}