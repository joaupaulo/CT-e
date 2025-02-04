using CTe.Application.Command;
using CTe.Application.Handler;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeApi.Tests.Handlers
{
    public class CriarTransportadoraHandlerTests
    {
        private readonly Mock<ITransportadoraRepository> _transportadoraRepositoryMock;
        private readonly CriarTransportadoraHandler _handler;

        private Endereco CriarEnderecoValido()
        {
            return new Endereco("Rua Exemplo", "123", "Cidade Exemplo", "EX");

        }

        public CriarTransportadoraHandlerTests()
        {
            _transportadoraRepositoryMock = new Mock<ITransportadoraRepository>();
            _handler = new CriarTransportadoraHandler(_transportadoraRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsTransportadoraId()
        {
            // Arrange
            var endereco = CriarEnderecoValido();
            var command = new CriarTransportadoraCommand("Transportadora XYZ", "12345678000199", endereco);
            var expectedTransportadoraId = 1;

            _transportadoraRepositoryMock
                .Setup(repo => repo.CriarAsync(It.IsAny<Transportadora>()))
                .ReturnsAsync(expectedTransportadoraId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedTransportadoraId, result);
            _transportadoraRepositoryMock.Verify(repo => repo.CriarAsync(It.IsAny<Transportadora>()), Times.Once);
        }
    }
}
