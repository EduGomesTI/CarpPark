using CarPark.Dominio.PessoaFisicaContext.Commands;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.Repositories;
using CarPark.Dominio.Shared.Commands;
using CarPark.Dominio.Shared.Interfaces;
using Flunt.Notifications;

namespace CarPark.Dominio.PessoaFisicaContext.Handlers
{
    public class PessoaFisicaHandler :
        Notifiable
        ,IHandler<AlterarPessoaFisicaCommand>
        ,IHandler<CadastrarPessoaFisicaCommand>
        ,IHandler<ExcluirPessoaFisicaCommand>
    {
        private readonly IPessoaFisicaRepository _repository;
        private PessoaFisica _pessoa;

        public PessoaFisicaHandler(IPessoaFisicaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AlterarPessoaFisicaCommand command)
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