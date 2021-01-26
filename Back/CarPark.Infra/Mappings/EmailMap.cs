using CarPark.Dominio.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Infra.Mappings
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");
            builder.HasKey(e => e.EmailId);
            builder.Property(e => e.EmailId).ValueGeneratedOnAdd();
            builder.Property(e => e.EnderecoEmail).HasMaxLength(160);
        }
    }
}