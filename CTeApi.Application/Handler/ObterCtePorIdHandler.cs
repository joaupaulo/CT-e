using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Application.Queries;
using CTe.Domain.AggregateRoot;
using CTe.Domain.Dto;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using MediatR;

namespace CTe.Application.Handler
{
    public class ObterCtePorIdHandler : IRequestHandler<ObterCtePorIdQuery, CteDto>
    {
        private readonly ICteRepository _repository;

        public ObterCtePorIdHandler(ICteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CteDto> Handle(ObterCtePorIdQuery request, CancellationToken cancellationToken)
        {
            var cte = await _repository.ObterPorIdAsync(request.Id);
            return cte ?? throw new QueryExecutionException($"CTe não encontrado {request.Id}");
        }
    }

}
