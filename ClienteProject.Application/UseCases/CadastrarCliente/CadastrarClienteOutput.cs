using ClienteProject.Domain.Entities;

namespace ClienteProject.Application.UseCases.CadastrarCliente;

public class CadastrarClienteOutput
{
    public CadastrarClienteOutput(Guid clienteId,
        string nome,
        string email)
    {
        Id = clienteId;
        Nome = nome;
        Email = email;
        DataCadastro = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }

    public static CadastrarClienteOutput FromEntity(Cliente cliente)
        => new CadastrarClienteOutput(cliente.Id, cliente.NomeCompleto, cliente.EmailPrincipal.ToString());

}
