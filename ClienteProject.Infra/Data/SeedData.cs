using Bogus;
using Bogus.Extensions.Brazil;
using ClienteProject.Domain.Entities;
using ClienteProject.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ClienteProject.Infra.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Clientes.Any())
                {
                    return; 
                }

                var locale = "pt_BR";

                var clienteFaker = new Faker<Cliente>(locale)
                    .RuleFor(c => c.NomeCompleto, f => f.Person.FullName)
                    .RuleFor(c => c.Cpf, f => new Cpf(f.Person.Cpf())) 
                    .RuleFor(c => c.EmailPrincipal, f => new EmailPrincipal(f.Person.Email))
                    .RuleFor(c => c.Telefone, f => new Telefone(f.Phone.PhoneNumber("## ########")))
                    .RuleFor(c => c.Endereco, f => new Endereco(f.Address.StreetAddress(),
                    f.Address.BuildingNumber(),
                    null,
                    f.Address.City(),
                    f.Address.City(),
                    f.Address.StateAbbr(),
                    f.Address.ZipCode()))
                    .RuleFor(c => c.Active, _ => true)
                    .RuleFor(c => c.EmailsSecundarios, _ => new List<EmailSecundario>());
                List<Cliente>? clientes = clienteFaker.Generate(100); 

                context.Clientes.AddRange(clientes);

                context.SaveChanges();
            }
        }
    }
}
