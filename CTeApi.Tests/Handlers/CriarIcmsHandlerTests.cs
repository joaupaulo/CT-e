using CTe.Application.Command;
using CTe.Application.Handler;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using Moq;
using System;


namespace CTeApi.Tests.Handlers
{
    public class CriarIcmsHandlerTests
    {
        private readonly Mock<IIcmsRepository> _icmsRepositoryMock;
        private readonly CriarIcmsHandler _handler;

        public CriarIcmsHandlerTests()
        {
            _icmsRepositoryMock = new Mock<IIcmsRepository>();
            _handler = new CriarIcmsHandler(_icmsRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_DeveRetornarAliquota_QuandoComandoValido()
        {
            // Arrange
            var comando = new CriarIcmsCommand("SP", "RJ", 1);
            var expectedAliquota = 1;

            _icmsRepositoryMock
                .Setup(repo => repo.InserirAsync(It.IsAny<IcmsAliquota>())).Returns(Task.FromResult(expectedAliquota));

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(expectedAliquota, result);
            _icmsRepositoryMock.Verify(repo => repo.InserirAsync(It.Is<IcmsAliquota>(
                ia => ia.UfOrigem == comando.UfOrigem &&
                      ia.UfDestino == comando.UfDestino &&
                      ia.Aliquota == comando.Aliquota)), Times.Once);
        }
    }
}
