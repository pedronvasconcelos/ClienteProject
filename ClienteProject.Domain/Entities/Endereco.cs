using ClienteProject.Domain.SeedOfWork;
using ClienteProject.Domain.Entities;
using ClienteProject.Domain.Exceptions;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Domain.Entities;
public class Endereco : Entity
{
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string? Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public Cep Cep { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }

    protected Endereco()
    {
    }

    public Endereco(string rua, string numero, string? complemento, string bairro, string cidade, string estado, string cep)
    {
        Validar(rua, numero, bairro, cidade, estado, cep);

        Logradouro = rua;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = new Cep(cep);
    }

    private void Validar(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {
        if (string.IsNullOrWhiteSpace(rua))
            throw new EnderecoException("O campo rua é obrigatório.");

        if (string.IsNullOrWhiteSpace(numero))
            throw new EnderecoException("O campo número é obrigatório.");

        if (string.IsNullOrWhiteSpace(bairro))
            throw new EnderecoException("O campo bairro é obrigatório.");

        if (string.IsNullOrWhiteSpace(cidade))
            throw new EnderecoException("O campo cidade é obrigatório.");

        if (string.IsNullOrWhiteSpace(estado))
            throw new EnderecoException("O campo estado é obrigatório.");

        if (string.IsNullOrWhiteSpace(cep))
            throw new EnderecoException("O campo CEP é obrigatório.");

    }

}

