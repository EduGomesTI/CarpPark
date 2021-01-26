using CarPark.Dominio.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infra.Mappings
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(t => t.TelefoneId);
            builder.Property(t => t.TelefoneId).ValueGeneratedOnAdd();
            builder.Property(t => t.Numero).HasMaxLength(11);
        }
    }
}