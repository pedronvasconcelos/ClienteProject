using ClienteProject.Domain.Exceptions;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Tests.Domain;
public class TelefoneTests
{
    [Theory]
    [InlineData("(12) 34567-8901")]
    [InlineData("12 34567-8901")]
    [InlineData("1234567-8901")]
    [InlineData("(12)34567-8901")]
    [InlineData("12-34567-8901")]
    [InlineData("12-345678901")]
    [InlineData("12345678901")]
    [InlineData("31999431515")]

    public void Telefone_ComNumeroValido_DeveSerCriadoCorretamente(string numeroValido)
    {
        // Act
        var telefone = new Telefone(numeroValido);

        // Assert
        Assert.Equal(Telefone.LimparNumero(numeroValido), telefone.Numero);
    }

    [Fact]
    public void Telefone_ComNumeroNulo_DeveLancarExcecao()
    {
        // Arrange
        string numeroNulo = null;

        // Act & Assert
        Assert.Throws<TelefoneException>(() => new Telefone(numeroNulo));
    }

    [Fact]
    public void Telefone_ComNumeroInvalido_DeveLancarExcecao()
    {
        // Arrange
        var numeroInvalido = "4567-8901";

        // Act & Assert
        Assert.Throws<TelefoneException>(() => new Telefone(numeroInvalido));
    }

    [Fact]
    public void Telefone_ComNumerosIguais_DeveRetornarVerdadeiro()
    {
        // Arrange
        var telefone1 = new Telefone("(12) 34567-8901");
        var telefone2 = new Telefone("(12) 34567-8901");

        // Act & Assert
        Assert.Equal(telefone1, telefone2);
        Assert.True(telefone1 == telefone2);
    }

    [Fact]
    public void Telefone_ComNumerosDiferentes_DeveRetornarFalso()
    {
        // Arrange
        var telefone1 = new Telefone("(12) 34567-8901");
        var telefone2 = new Telefone("(13) 45678-9012");

        // Act & Assert
        Assert.NotEqual(telefone1, telefone2);
        Assert.True(telefone1 != telefone2);
    }
}