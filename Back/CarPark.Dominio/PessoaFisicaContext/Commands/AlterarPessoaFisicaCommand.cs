using System;
using System.Collections.Generic;
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
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public List<int> TelefonesId { get; set; }
        public List<string> NumerosTel { get; set; }
        public List<int> EmailsId { get; set; }
        public List<string> EnderecosEmail { get; set; }
        // public Endereco Endereco { get; set; }
        // public ICollection<Telefone> Telefones { get; set; }
        // public ICollection<Email> Emails { get; set; }

        public AlterarPessoaFisicaCommand()
        {
        }

        public AlterarPessoaFisicaCommand(int pessoaFisicaId, string cPF, string nome, string sexo, DateTime dataNascimento, string rg,
            int enderecoId, string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado,
            List<int> telefonesId, List<string> numerosTel, List<int> emailsId, List<string> enderecosEmail)
        {
            PessoaFisicaId = pessoaFisicaId;
            CPF = cPF;
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Rg = rg;
            EnderecoId = enderecoId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            TelefonesId = telefonesId;
            NumerosTel = numerosTel;
            EmailsId = emailsId;
            EnderecosEmail = enderecosEmail;
        }
    }
}