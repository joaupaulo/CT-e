using CTe.Application.Handler;
using CTe.Application.Queries;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using Moq;


namespace CTeApi.Tests.Handlers
{
    public class ObterMotoristaPorIdHandlerTests
    {
        [Fact]
        public async Task Handle_MotoristaNaoExistente_LancaExcecao()
        {
            // Arrange
            var motoristaId = 1;
            var motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            motoristaRepositoryMock
                .Setup(repo => repo.ObterPorIdAsync(motoristaId))
                .ReturnsAsync((Motorista)null);

            var handler = new ObterMotoristaPorIdHandler(motoristaRepositoryMock.Object);
            var query = new ObterMotoristaPorIdQuery(motoristaId);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<QueryExecutionException>(() => handler.Handle(query, CancellationToken.None));
            Assert.Equal($"Motorista não encontrado no banco de dados ID {motoristaId}.", exception.Message);
        }
    }
}
