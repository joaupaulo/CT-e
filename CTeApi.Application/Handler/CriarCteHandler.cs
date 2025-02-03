using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Application.Command;
using CTe.Repository;
using CTe.Repository.Interface;
using CTe.Application.Queries;
using CTe.Domain.AggregateRoot;
using CTe.Domain.ValueObjects;
using MediatR;
using CTe.Shared.Exceptions;

namespace CTe.Application.Handler
{
    public class CriarCteHandler : IRequestHandler<CriarCteCommand, int>
    {
        private readonly ICteRepository _cteRepository;
        private readonly IMediator _mediator;

        public CriarCteHandler(ICteRepository cteRepository,

            IMediator mediator)
        {
            _cteRepository = cteRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CriarCteCommand request, CancellationToken cancellationToken)
        {

            var validationResult = request.Validate();
            if (validationResult.IsFailure)
            {
                throw new CommandValidationException(string.Join(", ", validationResult.Errors));
            }

            var transportadora = await _mediator.Send(new ObterTransportadoraPorIdQuery(request.TransportadoraId));
            var motorista = await _mediator.Send(new ObterMotoristaPorIdQuery(request.MotoristaId));
            var aliquota = await _mediator.Send(new ObterIcmsAliquotaQuery(request.Origem.Estado, request.Destino.Estado));

            var origem = new Endereco(request.Origem.Rua, request.Origem.Cidade, request.Origem.Estado, request.Origem.CEP);
            var destino = new Endereco(request.Destino.Rua, request.Destino.Cidade, request.Destino.Estado, request.Destino.CEP);
          
            var carga = new Carga(request.Carga.Peso,
                request.Carga.Volume,
                request.Carga.Pedagio,
                request.Carga.TarifaPorPeso,
                request.Carga.Carregamento);

            var cte = new Cte(transportadora, motorista, origem, destino, carga, aliquota);

            return await _cteRepository.CriarCteAsync(cte);
        }
    }

}
