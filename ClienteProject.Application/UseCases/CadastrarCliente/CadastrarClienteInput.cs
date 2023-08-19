using ClienteProject.Domain.Entities;
using MediatR;

namespace ClienteProject.Application.UseCases.CadastrarCliente;

public class CadastrarClienteInput : IRequest<CadastrarClienteOutput>
{
    public CadastrarClienteInput(string nome, string cpf, string email, string telefone, string cep, string logradouro, string numero, string? complemento, string bairro, string cidade, string estado)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;

    }

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public Cliente ToEntity()
    {
        var endereco = new Endereco(
              rua: Logradouro,
            numero: Numero,
            complemento: Complemento,
            bairro: Bairro,
            cidade: Cidade,
            estado: Estado,
            cep: Cep);
        return new Cliente(nomeCompleto: Nome,
            endereco,
            telefone: Telefone,
            emailPrincipal: Email,
            cpf: Cpf);
    }

}
