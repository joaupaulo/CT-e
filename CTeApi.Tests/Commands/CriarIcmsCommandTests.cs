using CTe.Application.Command;
using CTe.Shared.Exceptions;
using FluentAssertions;

namespace CTeApi.Tests.Commands
{
    public class CriarIcmsCommandTests
    {
        [Fact]
        public void Construtor_DeveInicializarPropriedades_QuandoParametrosValidos()
        {
            // Arrange
            var ufOrigem = "sp";
            var ufDestino = "rj";
            var aliquota = 18;

            // Act
            var command = new CriarIcmsCommand(ufOrigem, ufDestino, aliquota);

            // Assert
            command.UfOrigem.Should().Be("SP");
            command.UfDestino.Should().Be("RJ");
            command.Aliquota.Should().Be(aliquota);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoUfOrigemVazia()
        {
            // Arrange
            var ufOrigem = "";
            var ufDestino = "RJ";
            var aliquota = 18;

            // Act
            Action act = () => new CriarIcmsCommand(ufOrigem, ufDestino, aliquota);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("UF de origem não pode ser vazia.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoUfDestinoVazia()
        {
            // Arrange
            var ufOrigem = "SP";
            var ufDestino = "";
            var aliquota = 18;

            // Act
            Action act = () => new CriarIcmsCommand(ufOrigem, ufDestino, aliquota);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("UF de destino não pode ser vazia.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoAliquotaNaoPositiva()
        {
            // Arrange
            var ufOrigem = "SP";
            var ufDestino = "RJ";
            var aliquota = 0;

            // Act
            Action act = () => new CriarIcmsCommand(ufOrigem, ufDestino, aliquota);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("A alíquota deve ser um valor positivo.");
        }
    }
}
