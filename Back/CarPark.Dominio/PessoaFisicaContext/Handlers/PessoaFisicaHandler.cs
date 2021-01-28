using System.Collections.Generic;
using CarPark.Dominio.PessoaFisicaContext.Commands;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.Repositories;
using CarPark.Dominio.Shared.Commands;
using CarPark.Dominio.Shared.Entities;
using CarPark.Dominio.Shared.Interfaces;
using Flunt.Notifications;

namespace CarPark.Dominio.PessoaFisicaContext.Handlers
{
    public class PessoaFisicaHandler :
        Notifiable
        , IHandler<AlterarPessoaFisicaCommand>
        , IHandler<CadastrarPessoaFisicaCommand>
        , IHandler<ExcluirPessoaFisicaCommand>
    {
        private readonly IPessoaFisicaRepository _repository;
        private PessoaFisica _pessoa;
        private Endereco _endereco;
        private ICollection<Email> _emails;
        private ICollection<Telefone> _telefones;

        public PessoaFisicaHandler(IPessoaFisicaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AlterarPessoaFisicaCommand command)
        {
            //* Retorna os dados do Endereço
            _endereco = new Endereco(
                command.EnderecoId
                , command.Logradouro
                , command.Numero
                , command.Complemento
                , command.Cep
                , command.Bairro
                , command.Cidade
                , command.Estado
                , command.PessoaFisicaId
                , null
            );

            //* Retorna os dados dos E-mails
            _emails = new List<Email>();
            for (var i = 0; i < command.EmailsId.Count; i++)
            {
                _emails.Add(new Email(command.EmailsId[i], command.EnderecosEmail[i], command.PessoaFisicaId, null));
            }

            //* Retorna os dados dos telefones
            _telefones = new List<Telefone>();
            for (var i = 0; i < command.TelefonesId.Count; i++)
            {
                _telefones.Add(new Telefone(command.TelefonesId[i], command.NumerosTel[i], command.PessoaFisicaId, null));
            }


            _pessoa = new PessoaFisica(
                    command.PessoaFisicaId
                    , _endereco
                    , _telefones
                    , _emails
                    , command.CPF
                    , command.Nome
                    , command.Sexo
                    , command.DataNascimento
                    , command.Rg
                );

            if (_pessoa.Invalid)
                return new GenericCommandResult(false, "Dados inconsistentes.", _pessoa.Notifications);

            _repository.Alterar(_pessoa);

            return new GenericCommandResult(true, $"Dados de {command.Nome} alterado com sucesso.", _pessoa);
        }

        public ICommandResult Handle(CadastrarPessoaFisicaCommand command)
        {
            _pessoa = new PessoaFisica(
                command.Endereco
                , command.Telefones
                , command.Emails
                , command.CPF
                , command.Nome
                , command.Sexo
                , command.DataNascimento
                , command.Rg
            );

            if (_pessoa.Invalid)
                return new GenericCommandResult(false, "Dados inconsistentes.", _pessoa.Notifications);

            _repository.Cadastrar(_pessoa);

            return new GenericCommandResult(true, $"Cliente {command.Nome} cadastrado com sucesso.", _pessoa);
        }

        public ICommandResult Handle(ExcluirPessoaFisicaCommand command)
        {
            _pessoa = new PessoaFisica(
                 command.PessoaFisicaId
                 , command.Endereco
                 , command.Telefones
                 , command.Emails
                 , command.CPF
                 , command.Nome
                 , command.Sexo
                 , command.DataNascimento
                 , command.Rg
             );

            _repository.Excluir(_pessoa.PessoaFisicaId);

            return new GenericCommandResult(true, "Cliente exlcuido com sucesso.", "Cliente exlcuido com sucesso.");
        }
    }
}