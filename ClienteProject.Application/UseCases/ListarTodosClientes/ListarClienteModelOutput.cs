using ClienteProject.Domain.Entities;

namespace ClienteProject.Application.UseCases.ListarTodosClientes;

public class ListarClienteModelOutput
{
    public Guid Id { get; set; }
    
    public string Nome { get; set; }

    public string EmailPrincipal { get; set; }

    public string Telefone { get; set; }
    
    public string Cpf { get; set; } 

    public string Cep { get; set; }

    public ListarClienteModelOutput(Guid id, string nome, string emailPrincipal, string telefone, string cpf, string cep)
    {
        Id = id;
        Nome = nome;
        EmailPrincipal = emailPrincipal;
        Telefone = telefone;
        Cpf = cpf;
        Cep = cep;
    }

    public static ListarClienteModelOutput FromEntity(Cliente cliente)
    {
        return new ListarClienteModelOutput(cliente.Id, 
            cliente.NomeCompleto, 
            cliente.EmailPrincipal.ToString(), 
            cliente.Telefone.ToString(),
            cliente.Cpf.ToString(), 
            cliente.Endereco.Cep.ToString());
    }
}