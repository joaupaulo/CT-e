using CTe.Application.Command;
using CTe.Domain.Domain;
using CTe.Shared.Exceptions;
using FluentAssertions;

namespace CTeApi.Tests.Commands
{
    public class CriarTransportadoraCommandTests
    {

        private Endereco CriarEnderecoValido()
        {
            return new Endereco("Rua Exemplo", "123", "Cidade Exemplo", "EX");

        }

        [Fact]
        public void Construtor_DeveInicializarPropriedades_QuandoParametrosValidos()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();

            // Act
            var command = new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            command.Nome.Should().Be(nome);
            command.Cnpj.Should().Be(cnpj);
            command.Endereco.Should().Be(endereco);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoNomeVazio()
        {
            // Arrange
            var nome = "";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O nome da transportadora é obrigatório.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCnpjVazio()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "";
            var endereco = CriarEnderecoValido();

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CNPJ é obrigatório.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCnpjInvalido()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345";
            var endereco = CriarEnderecoValido();
            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CNPJ informado é inválido.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoEnderecoNulo()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            Endereco endereco = null;

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O endereço da transportadora é obrigatório.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoRuaVazia()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("A rua é obrigatória.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCidadeVazia()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();
            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("A cidade é obrigatória.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoEstadoVazio()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O estado é obrigatório.");
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoCepVazio()
        {
            // Arrange
            var nome = "Transportadora X";
            var cnpj = "12345678000195";
            var endereco = CriarEnderecoValido();

            // Act
            Action act = () => new CriarTransportadoraCommand(nome, cnpj, endereco);

            // Assert
            act.Should().Throw<CommandValidationException>()
                .WithMessage("O CEP é obrigatório.");
        }
    }
}
