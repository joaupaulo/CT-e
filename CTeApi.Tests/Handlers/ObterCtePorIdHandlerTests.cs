using CTe.Application.Handler;
using CTe.Application.Queries;
using CTe.Domain.Dto;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeApi.Tests.Handlers
{
    public class ObterCtePorIdHandlerTests
    {
        private readonly Mock<ICteRepository> _repositoryMock;
        private readonly ObterCtePorIdHandler _handler;

        public ObterCtePorIdHandlerTests()
        {
            _repositoryMock = new Mock<ICteRepository>();
            _handler = new ObterCtePorIdHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_CteExists_ReturnsCteDto()
        {
            // Arrange
            var cteId = 1;
            var expectedCte = new CteDto { id = cteId};
            _repositoryMock.Setup(repo => repo.ObterPorIdAsync(cteId))
                           .ReturnsAsync(expectedCte);

            var query = new ObterCtePorIdQuery(cteId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedCte, result);
            _repositoryMock.Verify(repo => repo.ObterPorIdAsync(cteId), Times.Once);
        }

        [Fact]
        public async Task Handle_CteDoesNotExist_ThrowsQueryExecutionException()
        {
            // Arrange
            var cteId = 1;
            _repositoryMock.Setup(repo => repo.ObterPorIdAsync(cteId))
                           .ReturnsAsync((CteDto)null);

            var query = new ObterCtePorIdQuery(cteId);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<QueryExecutionException>(() => _handler.Handle(query, CancellationToken.None));
            Assert.Equal($"CTe não encontrado {cteId}", exception.Message);
            _repositoryMock.Verify(repo => repo.ObterPorIdAsync(cteId), Times.Once);
        }
    }
}
