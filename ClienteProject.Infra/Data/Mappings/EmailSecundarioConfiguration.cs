using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Infra.Data.Mappings
{
    public class EmailSecundarioConfiguration : IEntityTypeConfiguration<EmailSecundario>
    {
        public void Configure(EntityTypeBuilder<EmailSecundario> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Endereco).HasColumnName("EnderecoEmail").IsRequired();
        }
    }
}
