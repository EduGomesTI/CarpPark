using CarPark.Dominio.PessoaFisicaContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infra.Mappings
{
    public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("PessoaFisica");
            builder.HasKey(p => p.PessoaFisicaId);
            builder.Property(p => p.PessoaFisicaId).ValueGeneratedOnAdd();
            builder.Property(p => p.CPF).HasMaxLength(11);
            builder.Property(p => p.DataNascimento);
            builder.Property(p => p.Nome).HasMaxLength(60);
            builder.Property(p => p.Rg).HasMaxLength(10);
            builder.Property(p => p.Sexo).HasMaxLength(2).IsFixedLength();

            builder.HasOne(p => p.Endereco);

            builder.HasMany(p => p.Emails);
            builder.HasMany(p => p.Telefones);
        }
    }
}