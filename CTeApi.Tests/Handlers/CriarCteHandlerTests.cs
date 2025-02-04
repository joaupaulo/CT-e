using CTe.Application.Command;
using CTe.Application.Handler;
using CTe.Application.Queries;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeApi.Tests.Handlers
{
    public class CriarCteHandlerTests
    {
        private readonly Mock<ICteRepository> _cteRepositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CriarCteHandler _handler;

        private Transportadora CriarTransportadoraValida()
        {
            return new Transportadora("Rua Exemplo", "123", "Cidade Exemplo", "EX", "Teste", "oi");

        }

        private Motorista CriarMotoristaValido()
        {
            return new Motorista("Rua Exemplo", "123", "Cidade Exemplo", "EX");

        }
        private Carga CriarCargaValida()
        {
            return new Carga(1,1,1,1,1);

        }

        private Endereco CriarEnderecoValido()
        {
            return new Endereco("Rua Exemplo", "123", "Cidade Exemplo", "EX");

        }

        public CriarCteHandlerTests()
        {
            _cteRepositoryMock = new Mock<ICteRepository>();
            _mediatorMock = new Mock<IMediator>();
            _handler = new CriarCteHandler(_cteRepositoryMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async Task Handle_DeveRetornarId_QuandoComandoValido()
        {
            // Arrange
            var comando = new CriarCteCommand
            {
               TransportadoraId = 1,
               MotoristaId = 2,
               Carga = CriarCargaValida(),
               Origem = CriarEnderecoValido(),
               Destino = CriarEnderecoValido()

            };

            var transportadora = CriarTransportadoraValida();
            var motorista = CriarMotoristaValido();
            var aliquota = 0.18m;

            _mediatorMock.Setup(m => m.Send(It.IsAny<ObterTransportadoraPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(transportadora);
            _mediatorMock.Setup(m => m.Send(It.IsAny<ObterMotoristaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(motorista);
            _mediatorMock.Setup(m => m.Send(It.IsAny<ObterIcmsAliquotaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(aliquota);
            _cteRepositoryMock.Setup(r => r.CriarCteAsync(It.IsAny<Cte>()))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public async Task Handle_DeveLancarExcecao_QuandoComandoInvalido()
        {
            // Arrange
            var comando = new CriarCteCommand
            {
         
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(comando, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<CommandValidationException>()
                .WithMessage("TransportadoraId deve ser maior que 0., MotoristaId deve ser maior que 0., Origem não pode ser nula., Destino não pode ser nulo., Carga não pode ser nula.");
        }
    }
}
