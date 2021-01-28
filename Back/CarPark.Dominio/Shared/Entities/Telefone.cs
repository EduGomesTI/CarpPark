using Flunt.Notifications;
using Flunt.Validations;
using Flunt.Br.Extensions;
using Newtonsoft.Json;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Entities;

namespace CarPark.Dominio.Shared.Entities
{
    public class Telefone : Notifiable
    {
        public int TelefoneId { get; private set; }
        public string Numero { get; private set; }
        public int? PessoaFisicaId { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
        public int? PessoaJuridicaId { get; private set; }
        public PessoaJuridica PessoaJuridica { get; private set; }

        protected Telefone() { }

        public Telefone(int telefoneId, string numero, int? pessoaFisicaId, int? pessoaJuridicaId)
        {
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            TelefoneId = telefoneId;
            AlterarNumero(numero);
        }

        [JsonConstructor]
        public Telefone(string numero)
        {
            AlterarNumero(numero);
        }

        public bool AlterarNumero(string numero)
        {
            //Retira os digitos DDD e verifica se é celular ou fixo
            var _numero = numero.Substring(2, numero.Length - 2);
            if (_numero.StartsWith('9'))
            {
                AddNotifications(
                new Contract()
                .IsNewFormatCellPhone(numero, "Telefone", "Telefone inválido.")
            );
            }
            else
            {
                AddNotifications(
                new Contract()
                .IsPhone(numero, "Telefone", "Telefone inválido.")
            );
            }

            if (Notifications.Count != 0)
                return false;

            Numero = numero;
            return true;
        }
    }
}