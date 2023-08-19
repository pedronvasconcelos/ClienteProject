using ClienteProject.Domain.Entities;
namespace ClienteProject.Domain.ValueObjects;

public class EmailSecundario : Email
{
    public Guid Id { get; private set; }

    public Cliente Cliente { get; private set; }

    public Guid ClienteId { get; private set;}

    public EmailSecundario(string endereco, Guid clienteId) : base(endereco)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
    }

    protected EmailSecundario() 
    {
    }
}
