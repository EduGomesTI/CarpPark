using CarPark.Dominio.PessoaFisicaContext.Commands;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaFisicaContext.Handlers;
using CarPark.Dominio.Repositories;
using CarPark.Dominio.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Api.Controllers
{
    [ApiController]
    [Route("v1/PessoaFisica")]
    public class PessoaFisicaController : ControllerBase
    {
        [Route("cpf/{cpf}")]
        [HttpGet]
        public PessoaFisica GetCPF(
            string cpf,
            [FromServices] IPessoaFisicaRepository repository)
        {
            return repository.GetCPF(cpf);
        }

        [Route("nome/{nome}")]
        [HttpGet]
        public PessoaFisica GetNome(
            string nome,
            [FromServices] IPessoaFisicaRepository repository)
        {
            return repository.GetNome(nome);
        }

        [Route("rg/{rg}")]
        [HttpGet]
        public PessoaFisica GetRG(
            string rg,
            [FromServices] IPessoaFisicaRepository repository)
        {
            return repository.GetRG(rg);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Cadastrar(
                [FromBody] CadastrarPessoaFisicaCommand command
                , [FromServices] PessoaFisicaHandler handler
                )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] AlterarPessoaFisicaCommand command,
            [FromServices] PessoaFisicaHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}