using CTe.Application.Queries;
using CTe.Repository.Interface;
using CTe.Domain.Domain;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Shared.Exceptions;

namespace CTe.Application.Handler
{
    public class ObrterIcmsAliquotaHandler : IRequestHandler<ObterIcmsAliquotaQuery, decimal>
    {
        private readonly IIcmsRepository _repository;

        public ObrterIcmsAliquotaHandler(IIcmsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<decimal> Handle(ObterIcmsAliquotaQuery request, CancellationToken cancellationToken)
        {
             decimal? aliquota = await _repository.BuscarPorUfAsync(request.UfOrigem, request.UfDestino);

            return aliquota ?? throw new QueryExecutionException($"Aliquota não encontrado no banco de dados.");

        }
    }

}
