using CTe.Application.Queries;
using CTe.Repository.Interface;
using CTe.Domain.AggregateRoot;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Shared.Exceptions;

namespace CTe.Application.Handler
{
    public class ObterMotoristaPorIdHandler : IRequestHandler<ObterMotoristaPorIdQuery, Motorista>
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public ObterMotoristaPorIdHandler(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }

        public async Task<Motorista> Handle(ObterMotoristaPorIdQuery request, CancellationToken cancellationToken)
        {
            var motorista = await _motoristaRepository.ObterPorIdAsync(request.Id);

            return motorista ?? throw new QueryExecutionException($"Motorista não encontrado no banco de dados ID {request.Id}.");
        }
    }

}
