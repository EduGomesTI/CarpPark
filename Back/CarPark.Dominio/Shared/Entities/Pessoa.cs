using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace CarPark.Dominio.Shared.Entities
{
    public abstract class Pessoa : Notifiable
    {
        public Endereco Endereco { get; private set; }
        public ICollection<Telefone> Telefones { get; private set; }
        public ICollection<Email> Emails { get; private set; }

        public Pessoa() { }

        public Pessoa(Endereco endereco, ICollection<Telefone> telefones, ICollection<Email> emails)
        {
            Endereco = endereco;
            Telefones = telefones;
            Emails = emails;

            //Adiciona Validações
            AddNotifications(Endereco);
            foreach (var telefone in Telefones)
            {
                AddNotifications(telefone);
            }
            foreach (var email in emails)
            {
                AddNotifications(email);
            }
        }
    }
}