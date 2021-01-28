using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using Newtonsoft.Json;

namespace CarPark.Dominio.Shared.Entities
{
    public class Email : Notifiable
    {
        public int EmailId { get; private set; }
        public string EnderecoEmail { get; private set; }
        public int? PessoaFisicaId { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
        public int? PessoaJuridicaId { get; private set; }
        public PessoaJuridica PessoaJuridica { get; private set; }

        protected Email() { }

        //Construtor para Método Put.
        public Email(int emailId, string enderecoEmail, int? pessoaFisicaId, int? pessoaJuridicaId)
        {
            EmailId = emailId;
            AlterarEmail(enderecoEmail);
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
        }

        [JsonConstructor]
        public Email(string enderecoEmail)
        {
            AlterarEmail(enderecoEmail);
        }
        public bool AlterarEmail(string enderecoEmail)
        {
            AddNotifications(
                new Contract()
                .IsEmail(enderecoEmail, "Email", $"Email inválido: {enderecoEmail}")
            );

            if (Notifications.Count != 0)
                return false;

            EnderecoEmail = enderecoEmail;
            return true;
        }

        public override string ToString()
        {
            return EnderecoEmail;
        }
    }
}