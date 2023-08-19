using ClienteProject.Domain.Entities;
using ClienteProject.Domain.SeedOfWork;
using ClienteProject.Domain.ValueObjects;
using ClienteProject.Domain.Exceptions;

namespace ClienteProject.Domain.Entities;
public class Cliente : AggregateRoot
{
    public string NomeCompleto { get; private set; }
    public Endereco Endereco { get; private set; }
    public Guid EnderecoId { get; private set; }
    public Telefone Telefone { get; private set; }
    public EmailPrincipal EmailPrincipal { get; private set; }
    public List<EmailSecundario> EmailsSecundarios { get; private set; }
    public Cpf Cpf { get; set; }
    public bool Active { get; set; }

    public Cliente()
    {
    }

    public Cliente(string nomeCompleto, 
        Endereco endereco,
        string telefone,
        string emailPrincipal,
        string cpf)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto ?? throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(nomeCompleto));
        Endereco = endereco;
        AtualizarTelefone(telefone);
        AtualizarEmailPrincipal(emailPrincipal);
        EmailsSecundarios = new List<EmailSecundario>();
        Cpf = new Cpf(cpf);
        Active = true;
    }

    public void AtualizarNome(string novoNome)
    {
        if(string.IsNullOrWhiteSpace(novoNome))
            throw new EntityValidationException("Nome não pode ser nulo ou vazio."); 
        NomeCompleto = novoNome ?? throw new EntityValidationException("Nome não pode ser nulo ou vazio.");
    }

    public void AtualizarEndereco(string rua,
        string numero,
        string? complemento,
        string bairro,
        string cidade,
        string estado,
        string cep)
    {
        Endereco = new Endereco(rua, numero, complemento, bairro, cidade, estado, cep)
            ?? throw new EntityValidationException("Endereço não pode ser nulo.");
    }

    public void AtualizarTelefone(string novoTelefone)
    {
        Telefone = new Telefone(novoTelefone) ?? throw new EntityValidationException("Telefone não pode ser nulo.");
    }

    public void AtualizarEmailPrincipal(string novoEmail)
    {
        EmailPrincipal = new EmailPrincipal(novoEmail) ?? throw new EntityValidationException("Email não pode ser nulo.");
    }

    public void AdicionarEmailSecundario(string email)
    {
        var emailObject = new EmailSecundario(email, Id);
        if (EmailsSecundarios.Any(e => e == emailObject))
            throw new InvalidOperationException("O email já existe na lista de emails secundários.");

        EmailsSecundarios.Add(emailObject);
    }

    public void RemoverEmailSecundario(EmailSecundario email)
    {
        if (!EmailsSecundarios.Remove(email))
            throw new InvalidOperationException("O email informado não está na lista de emails secundários.");
    }
}