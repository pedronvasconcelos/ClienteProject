using ClienteProject.Application.UseCases.CadastrarCliente;
using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using ClienteProject.Infra.Data;
using ClienteProject.Infra.Data.Repositories;
using MediatR;
using System.Reflection;

namespace ClienteProject.Api.Configurations;
public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
    {
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }

}

