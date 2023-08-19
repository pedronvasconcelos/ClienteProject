using ClienteProject.Domain.Entities;
using ClienteProject.Domain.Exceptions;
using ClienteProject.Domain.ValueObjects;
using FluentAssertions;

namespace ClienteProject.Tests.Domain;
public class ClienteTests
{
    [Fact]
    public void Cliente_ComDadosValidos_DeveSerCriadoCorretamente()
    {
        // Arrange & Act
        var endereco = new Endereco(rua: "Rua Teste",
            numero: "123",
            complemento: "Apto 101",
            bairro: "Centro",
            cidade: "São Paulo",
            estado: "SP",
            cep: "12345-678");
        var cliente = new Cliente(
            nomeCompleto: "João Silva",
            endereco,
            telefone: "(11) 98765-4321",
            emailPrincipal: "joao@example.com",
            cpf: "52998224725"
        );

        // Assert
        cliente.NomeCompleto.Should().Be("João Silva");
        cliente.Telefone.Numero.Should().Be("11987654321");
        cliente.EmailPrincipal.Endereco.Should().Be("joao@example.com");
    }

    [Fact]
    public void AtualizarNome_ComNomeValido_DeveAtualizarCorretamente()
    {
        // Arrange
        var cliente = CreateValidCliente();

        // Act
        cliente.AtualizarNome("João A. Silva");

        // Assert
        cliente.NomeCompleto.Should().Be("João A. Silva");
    }

    [Fact]
    public void AtualizarNome_ComNomeInvalido_DeveLancarException()
    {
        // Arrange
        var cliente = CreateValidCliente();

        // Act & Assert
        Action act = () => cliente.AtualizarNome("");
        act.Should().Throw<EntityValidationException>().WithMessage("Nome não pode ser nulo ou vazio.");
    }

    [Fact]
    public void AdicionarEmailSecundario_ComEmailValido_DeveAdicionarCorretamente()
    {
        // Arrange
        var cliente = CreateValidCliente();

        // Act
        cliente.AdicionarEmailSecundario("joao.secundario@example.com");

        // Assert
        cliente.EmailsSecundarios.Should().Contain(new EmailSecundario("joao.secundario@example.com", cliente.Id));
    }

    [Fact]
    public void AdicionarEmailSecundario_ComEmailDuplicado_DeveLancarException()
    {
        // Arrange
        var cliente = CreateValidCliente();
        cliente.AdicionarEmailSecundario("joao.duplicado@example.com");

        // Act & Assert
        Action act = () => cliente.AdicionarEmailSecundario("joao.duplicado@example.com");
        act.Should().Throw<InvalidOperationException>().WithMessage("O email já existe na lista de emails secundários.");
    }

    [Fact]
    public void RemoverEmailSecundario_ComEmailExistente_DeveRemoverCorretamente()
    {
        // Arrange
        var cliente = CreateValidCliente();
        var emailToRemove = new EmailSecundario("joao.remover@example.com", cliente.Id);
        cliente.AdicionarEmailSecundario(emailToRemove.Endereco);

        // Act
        cliente.RemoverEmailSecundario(emailToRemove);

        // Assert
        cliente.EmailsSecundarios.Should().NotContain(emailToRemove);
    }

    [Fact]
    public void RemoverEmailSecundario_ComEmailInexistente_DeveLancarException()
    {
        // Arrange
        var cliente = CreateValidCliente();

        // Act & Assert
        Action act = () => cliente.RemoverEmailSecundario(new EmailSecundario("joao.inexistente@example.com", cliente.Id));
        act.Should().Throw<InvalidOperationException>().WithMessage("O email informado não está na lista de emails secundários.");
    }

    private Cliente CreateValidCliente()
    {
        var endereco = new Endereco(rua: "Rua Teste",
         numero: "123",
         complemento: "Apto 101",
         bairro: "Centro",
         cidade: "São Paulo",
         estado: "SP",
         cep: "12345-678");
        return new Cliente(
            nomeCompleto: "João Silva",
            endereco,
            telefone: "(11) 98765-4321",
            emailPrincipal: "joao@example.com",
            cpf: "52998224725"
        );
    }
}