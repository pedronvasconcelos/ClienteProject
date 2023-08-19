using ClienteProject.Domain.ValueObjects;
using ClienteProject.Domain.Exceptions;

namespace ClienteProject.Tests.Domain;

public class CpfTests
{
    [Theory]
    [InlineData("52998224725")]
    [InlineData("12345678909")]
    [InlineData("11144477735")]
    public void Cpf_ComNumeroValido_DeveSerCriadoSemErros(string cpfValido)
    {
        //Arrange
        var cpf = new Cpf(cpfValido);

        //Act && Assert
        Assert.NotNull(cpf);
        Assert.Equal(cpfValido, cpf.Numero);
    }

    [Theory]
    [InlineData("52998224724")]   
    [InlineData("11111111111")]   
    [InlineData("52998224")]     
    [InlineData("529982247259")]  
    public void Cpf_ComNumeroInvalido_DeveLancarExcecao(string cpfInvalido)
    {
        // Act & Assert
        Assert.Throws<EntityValidationException>(() => new Cpf(cpfInvalido));
    }


    [Fact]
    public void Cpf_MesmoNumero_DeveSerIgual()
    {
        //Arrange
        var cpf1 = new Cpf("52998224725");
        var cpf2 = new Cpf("52998224725");

        // Act & Assert
        Assert.Equal(cpf1, cpf2);
    }

    [Fact]
    public void Cpf_NumerosDiferentes_DeveSerDiferente()
    {
        //Arrange
        var cpf1 = new Cpf("52998224725");
        var cpf2 = new Cpf("12345678909");

        //Act & Assert
        Assert.NotEqual(cpf1, cpf2);
    }
}