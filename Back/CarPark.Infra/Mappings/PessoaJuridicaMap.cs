using CarPark.Dominio.PessoaJuridicaContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Infra.Mappings
{
    public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("PessoaJuridica");
            builder.HasKey(p => p.PessoaJuridicaId);
            builder.Property(p => p.PessoaJuridicaId).ValueGeneratedOnAdd();
            builder.Property(p => p.CNPJ).HasMaxLength(11);
            builder.Property(p => p.RazaoSocial).HasMaxLength(100);
            builder.Property(p => p.NomeFantasia).HasMaxLength(100);

            builder.HasOne(p => p.Endereco);

            builder.HasMany(p => p.Emails);
            builder.HasMany(p => p.Telefones);
        }
    }
}