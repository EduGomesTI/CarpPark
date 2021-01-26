using CarPark.Dominio.Shared.Interfaces;

namespace CarPark.Dominio.Shared.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }

        public GenericCommandResult()
        {
        }
        
        public GenericCommandResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }
        
    }
}