using CTe.Application.Handler;
using CTe.Application.Queries;
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
    public class ObterIcmsAliquotaHandlerTests
    {
        private readonly Mock<IIcmsRepository> _repositoryMock;
        private readonly ObrterIcmsAliquotaHandler _handler;

        public ObterIcmsAliquotaHandlerTests()
        {
            _repositoryMock = new Mock<IIcmsRepository>();
            _handler = new ObrterIcmsAliquotaHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_AliquotaExists_ReturnsAliquota()
        {
            // Arrange
            var ufOrigem = "SP";
            var ufDestino = "RJ";
            var expectedAliquota = 0.18m;
            _repositoryMock.Setup(repo => repo.BuscarPorUfAsync(ufOrigem, ufDestino))
                           .ReturnsAsync(expectedAliquota);

            var query = new ObterIcmsAliquotaQuery(ufOrigem, ufDestino);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedAliquota, result);
            _repositoryMock.Verify(repo => repo.BuscarPorUfAsync(ufOrigem, ufDestino), Times.Once);
        }
    }
}
