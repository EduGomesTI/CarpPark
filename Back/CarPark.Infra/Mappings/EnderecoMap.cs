using CarPark.Dominio.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infra.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {


            builder.ToTable("Endereco");
            builder.HasKey(e => e.EnderecoId);
            builder.Property(e => e.EnderecoId).ValueGeneratedOnAdd();
            builder.Property(e => e.Logradouro).HasMaxLength(100);
            builder.Property(e => e.Numero).HasMaxLength(5);
            builder.Property(e => e.Complemento).HasMaxLength(10);
            builder.Property(e => e.CEP).HasMaxLength(8).IsFixedLength();
            builder.Property(e => e.Bairro).HasMaxLength(40);
            builder.Property(e => e.Cidade).HasMaxLength(30);
            builder.Property(e => e.Estado).HasMaxLength(2).IsFixedLength();

            builder.HasOne(pf => pf.PessoaFisica);
            builder.HasOne(pj => pj.PessoaJuridica);
        }
    }
}