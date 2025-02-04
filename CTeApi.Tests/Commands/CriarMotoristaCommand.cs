using CTe.Application.Command;
using CTe.Shared.Exceptions;
using FluentAssertions;


namespace CTeApi.Tests.Commands
{
    public class CriarMotoristaCommandTests
    {
        [Fact]
        public void Construtor_DeveInicializarPropriedades_QuandoParametrosValidos()
        {
            // Arrange
            var nome = "João da Silva";
            var cpf = "12345678901";
            var telefone = "1234567890";
            var cnh = "123456789012345";

            // Act
            var command = new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            command.Nome.Should().Be(nome);
            command.Cpf.Should().Be(cpf);
            command.Telefone.Should().Be(telefone);
            command.Cnh.Should().Be(cnh);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoNomeVazio()
        {
            // Arrange
            var nome = "";
            var cpf = "12345678901";
            var telefone = "1234567890";
            var cnh = "123456789012345";

            // Act
            Action act = () => new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O nome do motorista é obrigatório.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCpfVazio()
        {
            // Arrange
            var nome = "João da Silva";
            var cpf = "";
            var telefone = "1234567890";
            var cnh = "123456789012345";

            // Act
            Action act = () => new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CPF é obrigatório.\", but \"O CPF é obrigatório., O CPF informado é inválido.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCpfInvalido()
        {
            // Arrange
            var nome = "João da Silva";
            var cpf = "12345";
            var telefone = "1234567890";
            var cnh = "123456789012345";

            // Act
            Action act = () => new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CPF informado é inválido.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCnhVazio()
        {
            // Arrange
            var nome = "João da Silva";
            var cpf = "12345678901";
            var telefone = "1234567890";
            var cnh = "";

            // Act
            Action act = () => new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CNH informado é inválido.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoTelefoneVazio()
        {
            // Arrange
            var nome = "João da Silva";
            var cpf = "12345678901";
            var telefone = "";
            var cnh = "123456789012345";

            // Act
            Action act = () => new CriarMotoristaCommand(nome, cpf, telefone, cnh);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O telefone é obrigatório.");
        }
    }
}
