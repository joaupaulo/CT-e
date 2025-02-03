using CTe.Application.Queries;
using CTe.Domain.AggregateRoot;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Handler
{
    public class ObterTransportadoraPorIdHandler : IRequestHandler<ObterTransportadoraPorIdQuery, Transportadora>
    {
        private readonly ITransportadoraRepository _repository;

        public ObterTransportadoraPorIdHandler(ITransportadoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Transportadora> Handle(ObterTransportadoraPorIdQuery request, CancellationToken cancellationToken)
        {
            var transportadora =await _repository.ObterPorIdAsync(request.Id);

           return transportadora ?? throw new QueryExecutionException($"Motorista não encontrado no banco de dados ID {request.Id}.");

        }
    }
}
