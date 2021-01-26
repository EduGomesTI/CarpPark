using CarPark.Dominio.PessoaJuridicaContext.Commands;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.Repositories;
using CarPark.Dominio.Shared.Commands;
using CarPark.Dominio.Shared.Interfaces;
using Flunt.Notifications;

namespace CarPark.Dominio.PessoaJuridicaContext.Handlers
{
    public class PessoaJuridicaHandler :
        Notifiable
        ,IHandler<AlterarPessoaJuridicaCommand>
        ,IHandler<CadastrarPessoaJuridicaCommand>
        ,IHandler<ExcluirPessoaJuridicaCommand>
    {
        private readonly IPessoaJuridicaRepository _repository;
        private PessoaJuridica _pj;

        public PessoaJuridicaHandler(IPessoaJuridicaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AlterarPessoaJuridicaCommand command)
        {
            _pj = new PessoaJuridica(
                command.Id
                , command.Endereco
                , command.Telefones
                , command.Emails
                , command.CNPJ
                , command.RazaoSocial
                , command.NomeFantasia
            );

            if (_pj.Invalid)
                return new GenericCommandResult(false, "Dados inconsistentes.", _pj.Notifications);

            _repository.Alterar(_pj);

            return new GenericCommandResult(true, $"Dados de {command.RazaoSocial} alterado com sucesso.", _pj);
        }

        public ICommandResult Handle(CadastrarPessoaJuridicaCommand command)
        {

            _pj = new PessoaJuridica(
                command.Endereco
                , command.Telefones
                , command.Emails
                , command.CNPJ
                , command.RazaoSocial
                , command.NomeFantasia
            );

            if (_pj.Invalid)
                return new GenericCommandResult(false, "Dados inconsistentes.", _pj.Notifications);

            _repository.Cadastrar(_pj); 

            return new GenericCommandResult(true, $"Cliente {command.RazaoSocial} cadastrado com sucesso.", _pj);
        }

        public ICommandResult Handle(ExcluirPessoaJuridicaCommand command)
        {
           _pj = new PessoaJuridica(
                command.Id
                , command.Endereco
                , command.Telefones
                , command.Emails
                , command.CNPJ
                , command.RazaoSocial
                , command.NomeFantasia
            ); 

            _repository.Excluir(_pj.PessoaJuridicaId);

            return new GenericCommandResult(true, "Cliente exlcuido com sucesso.", "Cliente exlcuido com sucesso.");
        }
    }
}