using ClienteProject.Api.Configurations;
using ClienteProject.Application.UseCases.CadastrarCliente;
using ClienteProject.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAndConfigureControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbConnection(builder.Configuration);
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CadastrarCliente).GetTypeInfo().Assembly));

var app = builder.Build();

app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();  
    }
}


app.Run();
