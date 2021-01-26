using CarPark.Dominio.PessoaJuridicaContext.Commands;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Handlers;
using CarPark.Dominio.Repositories;
using CarPark.Dominio.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Api.Controllers
{
    [ApiController]
    [Route("v1/PessoaJuridica")]
    public class PessoaJuridicaController : ControllerBase
    {
        [Route("cnpj/{cnpj}")]
        [HttpGet]
        public PessoaJuridica GetCNPJ(
            string cnpj,
            [FromServices] IPessoaJuridicaRepository repository)
        {
            return repository.GetCNPJ(cnpj);
        }

        [Route("razaosocial/{razaoSocial}")]
        [HttpGet]
        public PessoaJuridica GetRazaoSocial(
            string razaoSocial,
            [FromServices] IPessoaJuridicaRepository repository)
        {
            return repository.GetRazaoSocial(razaoSocial);
        }

        [Route("nomefantasia/{nomefantasia}")]
        [HttpGet]
        public PessoaJuridica GetNomeFantasia(
            string nomeFantasia,
            [FromServices] IPessoaJuridicaRepository repository)
        {
            return repository.GetNomeFantasia(nomeFantasia);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Cadastrar(
            [FromBody] CadastrarPessoaJuridicaCommand command
            , [FromServices] PessoaJuridicaHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Alterar(
            [FromBody] AlterarPessoaJuridicaCommand command,
            [FromServices] PessoaJuridicaHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}