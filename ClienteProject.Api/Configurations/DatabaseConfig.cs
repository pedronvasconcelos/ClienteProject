using ClienteProject.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ClienteProject.Api.Configurations;
public static class DatabaseConfig
{
    public static IServiceCollection AddDbConnection(
           this IServiceCollection services,
           IConfiguration configuration
       )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (env == "Development" || env == "Docker")
        
            SeedData.Initialize(services.BuildServiceProvider());
        return services;
    }
}


