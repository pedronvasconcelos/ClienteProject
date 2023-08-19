using ClienteProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Infra.Data.Mappings
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.Property(e => e.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .IsRequired();

            builder.OwnsOne(e => e.Cpf)
              .Property(cpf => cpf.Numero)  
              .HasColumnName("Cpf");

            builder.OwnsOne(e => e.EmailPrincipal)
                .Property(email => email.Endereco)
                .HasColumnName("EmailPrincipal");

            builder.OwnsOne(e => e.Telefone)
                .Property(telefone => telefone.Numero)
                .HasColumnName("Telefone");

            builder.HasOne(e => e.Endereco)
                   .WithOne(d => d.Cliente)
                   .HasForeignKey<Endereco>(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Endereco)
                   .WithOne(d => d.Cliente)
                   .HasForeignKey<Endereco>(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.EmailsSecundarios).WithOne(e => e.Cliente);
        }
    }


}
