using CTe.Application.Command;
using CTe.Domain.Domain;
using FluentAssertions;

namespace CTeApi.Tests.Commands
{
    public class CriarCteCommandTests
    {

        private Endereco CriarEnderecoValido()
        {
            return new Endereco("Rua Exemplo", "123", "Cidade Exemplo","EX");
         
        }

        private Carga CriarCargaValida()
        {
            return new Carga(10000,10,10,10,10);
        }


        [Fact]
        public void Validate_DeveRetornarSucesso_QuandoTodosOsCamposSaoValidos()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 1,
                MotoristaId = 1,
                Origem = CriarEnderecoValido(), 
                Destino = CriarEnderecoValido(), 
                Carga = CriarCargaValida() 
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Validate_DeveRetornarErro_QuandoTransportadoraIdForInvalido()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 0, 
                MotoristaId = 1,
                Origem = CriarEnderecoValido(),
                Destino = CriarEnderecoValido(),
                Carga = CriarCargaValida()
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().Contain("TransportadoraId deve ser maior que 0.");
        }

        [Fact]
        public void Validate_DeveRetornarErro_QuandoMotoristaIdForInvalido()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 1,
                MotoristaId = 0, 
                Origem = CriarEnderecoValido(),
                Destino = CriarEnderecoValido(),
                Carga = CriarCargaValida()
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().Contain("MotoristaId deve ser maior que 0.");
        }

        [Fact]
        public void Validate_DeveRetornarErro_QuandoOrigemForNula()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 1,
                MotoristaId = 1,
                Origem = null, 
                Destino = CriarEnderecoValido(),
                Carga = CriarCargaValida()
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().Contain("Origem não pode ser nula.");
        }

        [Fact]
        public void Validate_DeveRetornarErro_QuandoDestinoForNulo()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 1,
                MotoristaId = 1,
                Origem = CriarEnderecoValido(),
                Destino = null, 
                Carga = CriarCargaValida()
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().Contain("Destino não pode ser nulo.");
        }

        [Fact]
        public void Validate_DeveRetornarErro_QuandoCargaForNula()
        {
            // Arrange
            var command = new CriarCteCommand
            {
                TransportadoraId = 1,
                MotoristaId = 1,
                Origem = CriarEnderecoValido(),
                Destino = CriarEnderecoValido(),
                Carga = null 
            };

            // Act
            var result = command.Validate();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().Contain("Carga não pode ser nula.");
        }
    }
}