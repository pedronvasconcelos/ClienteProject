using ClienteProject.Domain.Entities;
using ClienteProject.Domain.Exceptions;
using ClienteProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteProject.Tests.Domain;
public class EnderecoTests
{
    [Fact]
    public void Endereco_InicializacaoCorreta_DeveCriarEndereco()
    {
        // Arrange
        var rua = "Rua Exemplo";
        var numero = "123";
        var complemento = "Apto 101";
        var bairro = "Centro";
        var cidade = "Cidade Exemplo";
        var estado = "Estado Exemplo";
        var cep = "12345-678";

        // Act
        var endereco = new Endereco(rua, numero, complemento, bairro, cidade, estado, cep);

        // Assert
        Assert.Equal(rua, endereco.Logradouro);
        Assert.Equal(numero, endereco.Numero);
        Assert.Equal(complemento, endereco.Complemento);
        Assert.Equal(bairro, endereco.Bairro);
        Assert.Equal(cidade, endereco.Cidade);
        Assert.Equal(estado, endereco.Estado);
        Assert.Equal(cep, endereco.Cep.ToString());
    }

    [Theory]
    [InlineData(null, "123", "Centro", "Cidade", "Estado", "12345-678")]
    [InlineData("Rua Exemplo", null, "Centro", "Cidade", "Estado", "12345-678")]
    [InlineData("Rua Exemplo", "123", null, "Cidade", "Estado", "12345-678")]
    [InlineData("Rua Exemplo", "123", "Centro", null, "Estado", "12345-678")]
    [InlineData("Rua Exemplo", "123", "Centro", "Cidade", null, "12345-678")]
    [InlineData("Rua Exemplo", "123", "Centro", "Cidade", "Estado", null)]
    public void Endereco_CamposNulos_DeveRetornarExcecao(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {
        // Arrange & Act & Assert
        Assert.Throws<EnderecoException>(() => new Endereco(rua, numero, null, bairro, cidade, estado, cep));
    }

    [Theory]
    [InlineData("12345678")]
    [InlineData("12345-678")]
    public void Cep_FormatosValidos_DeveSerCriadoCorretamente(string cepValor)
    {
        // Arrange & Act
        var cep = new Cep(cepValor);

        // Assert
        Assert.Equal(cepValor, cep.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("1234567")]
    [InlineData("12-45-678")]
    [InlineData("abcdefgh")]
    public void Cep_FormatosInvalidos_DeveRetornarExcecao(string cepValor)
    {
        // Arrange & Act & Assert
        Assert.Throws<EnderecoException>(() => new Cep(cepValor));
    }
}