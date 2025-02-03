using CTe.Application.Command;
using CTe.Repository.Interface;
using CTe.Shared.Exceptions;
using CTe.Domain.AggregateRoot;
using CTe.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Handler
{
    public class CriarMotoristaHandler : IRequestHandler<CriarMotoristaCommand, int>
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public CriarMotoristaHandler(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }

        public async Task<int> Handle(CriarMotoristaCommand request, CancellationToken cancellationToken)
        {
            var motorista = new Motorista(request.Nome, request.Cpf, request.Telefone, request.Cnh);

            return await _motoristaRepository.CriarAsync(motorista);
        }
    }
}
