using ClienteProject.Api.Filters;

namespace ClienteProject.Api.Configurations;

public static class ControllersConfig
{

    public static IServiceCollection AddAndConfigureControllers(
       this IServiceCollection services
   )
    {
        services
            .AddControllers(options
                => options.Filters.Add(typeof(ApiExceptionFilter))
            );
        services.AddDocumentation();
        return services;
    }
    private static IServiceCollection AddDocumentation(
        this IServiceCollection services
    )
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    public static WebApplication UseDocumentation(
       this WebApplication app
   )
    {
        if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}


