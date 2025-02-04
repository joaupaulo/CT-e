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
    public class CriarMotoristaHandlerTests
    {
        private readonly Mock<IMotoristaRepository> _motoristaRepositoryMock;
        private readonly CriarMotoristaHandler _handler;

        public CriarMotoristaHandlerTests()
        {
            _motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            _handler = new CriarMotoristaHandler(_motoristaRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsMotoristaId()
        {
            // Arrange
            var command = new CriarMotoristaCommand("João Silva", "12345678901", "11999999999", "ABC123456");
            var expectedMotoristaId = 1;

            _motoristaRepositoryMock
                .Setup(repo => repo.CriarAsync(It.IsAny<Motorista>()))
                .ReturnsAsync(expectedMotoristaId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedMotoristaId, result);
            _motoristaRepositoryMock.Verify(repo => repo.CriarAsync(It.IsAny<Motorista>()), Times.Once);
        }
    }
}
