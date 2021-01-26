using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Newtonsoft.Json;

namespace CarPark.Dominio.Shared.Entities
{
    public class Endereco : Notifiable
    {
        public int EnderecoId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public int? PessoaFisicaId { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
        public int? PessoaJuridicaId { get; private set; }
        public PessoaJuridica PessoaJuridica { get; private set; }

        protected Endereco() { }

        [JsonConstructor]
        public Endereco(int enderecoId, string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            EnderecoId = enderecoId;
            AlterarLogradouro(logradouro);
            AlterarNumero(numero);
            AlterarComplemento(complemento);
            AlterarCEP(cep);
            AlterarBairro(bairro);
            AlterarCidade(cidade);
            AlterarEstado(estado);
        }

        public bool AlterarLogradouro(string logradouro)
        {
            AddNotifications(
                new Contract()
                .IsBetween(logradouro.Length, 3, 100, "Logradouro", "Logradouro deve ter entre 3 e 100 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Logradouro = logradouro;
            return true;
        }

        public bool AlterarNumero(string numero)
        {
            AddNotifications(
                new Contract()
                .IsBetween(numero.Length, 1, 5, "Numero", "Numero deve ter entre 1 e 5 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Numero = numero;
            return true;
        }


        public bool AlterarComplemento(string complemento)
        {
            AddNotifications(
                new Contract()
                .HasMaxLengthIfNotNullOrEmpty(complemento, 10, "Complemento", "Complemento deve ter no máximo 10 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Complemento = complemento;
            return true;
        }

        public bool AlterarCEP(string cep)
        {
            AddNotifications(
                new Contract()
                .IsCep(cep, "CEP", "CEP inválido.")
            );

            if (Notifications.Count != 0)
                return false;

            CEP = cep.Replace("-", "");
            return true;
        }

        public bool AlterarBairro(string bairro)
        {
            AddNotifications(
                new Contract()
                .IsBetween(bairro.Length, 3, 40, "Bairro", "Bairro deve ter entre 3 e 20 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Bairro = bairro;
            return true;
        }

        public bool AlterarCidade(string cidade)
        {
            AddNotifications(
                new Contract()
                .IsBetween(cidade.Length, 3, 30, "Cidade", "Cidade deve ter entre 3 e 15 caracteres.")
            );

            if (Notifications.Count != 0)
                return false;

            Cidade = cidade;
            return true;
        }

        public bool AlterarEstado(string estado)
        {
            AddNotifications(
                new Contract()
                .HasLen(estado, 2, "Estado", "Estado inválido")
            );

            if (Notifications.Count != 0)
                return false;


            Estado = estado;
            return true;
        }
    }
}