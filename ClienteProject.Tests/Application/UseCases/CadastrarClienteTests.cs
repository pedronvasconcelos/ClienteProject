using ClienteProject.Application.UseCases.CadastrarCliente;
using ClienteProject.Domain.Entities;
using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteProject.Tests.Application.UseCases;
public class CadastrarClienteTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IClienteRepository> _clienteRepositoryMock = new();

    [Fact]
    public async void Handle_ShouldCreateClienteAndReturnOutput()
    {
        // Arrange
        var input = new CadastrarClienteInput(
            nome: "Joao Fulano",
            cpf: "188.250.840-80",
            email: "joao.fulano@example.com",
            telefone: "3199999999",
            cep: "12345-678",
            logradouro: "Rua Teste",
            numero: "42",
            complemento: null,
            bairro: "Bairro",
            cidade: "Cidade",
            estado: "SP"
        );

        var expectedCliente = input.ToEntity();
        _clienteRepositoryMock.Setup(r => r.Insert(It.IsAny<Cliente>(), default));

        var handler = new CadastrarCliente(_clienteRepositoryMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(input, default);

        // Assert
        Assert.Equal(expectedCliente.NomeCompleto, result.Nome);
        Assert.Equal(expectedCliente.EmailPrincipal.ToString(), result.Email);
    }

}