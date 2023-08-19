using ClienteProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClienteProject.Infra.Data.Mappings
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id").IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .IsRequired().
                HasMaxLength(20);
            builder.Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .IsRequired().
                HasMaxLength(100);
            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .IsRequired().HasMaxLength(2);

            builder.OwnsOne(e => e.Cep)
                   .Property(x => x.Valor)
                   .HasColumnName("Cep");

            builder.HasOne(e => e.Cliente)
                   .WithOne(c => c.Endereco)
                   .HasForeignKey<Endereco>(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
