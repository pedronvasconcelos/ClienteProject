using ClienteProject.Domain.Exceptions;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Tests.Domain
{
    public class EmailTests
    {
        [Fact]
        public void Email_ComEmailValido_DeveConstruirCorretamente()
        {
            // Arrange
            string validAddress = "example@test.com";

            // Act
            var email = new EmailPrincipal(validAddress);

            // Assert
            Assert.Equal(validAddress, email.Endereco);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalidEmail")]
        [InlineData("missingAtSign.com")]
        [InlineData("missingDot@com")]
        public void Email_ComEnderecoInvalido_DeveGerarExcecao(string invalidAddress)
        {
            // Act & Assert
            Assert.Throws<EmailException>(() => new EmailPrincipal(invalidAddress));
        }

        [Fact]
        public void Email_ComMesmoEndereco_DeveRetornarIgual()
        {
            // Arrange
            var email1 = new EmailPrincipal("same@example.com");
            var email2 = new EmailPrincipal("same@example.com");

            // Act & Assert
            Assert.Equal(email1, email2);
            Assert.True(email1 == email2);
        }

        [Fact]
        public void Email_ComEnderecoDiferente_DeveRetornarFalso()
        {
            // Arrange
            var email1 = new EmailPrincipal("one@example.com");
            var email2 = new EmailPrincipal("two@example.com");

            // Act & Assert
            Assert.NotEqual(email1, email2);
            Assert.True(email1 != email2);
        }

        [Fact]
        public void Email_ToString_DeveRetornarEndereco()
        {
            // Arrange
            var email = new EmailPrincipal("example@test.com");

            // Act
            var result = email.ToString();

            // Assert
            Assert.Equal("example@test.com", result);
        }
    }
}
