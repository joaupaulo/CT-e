using CTe.Application.Command;
using CTe.Domain.AggregateRoot;
using CTe.Domain.ValueObjects;
using CTe.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Handler
{
    public class CriarTransportadoraHandler : IRequestHandler<CriarTransportadoraCommand, int>
    {
        private readonly ITransportadoraRepository _transportadoraRepository;

        public CriarTransportadoraHandler(ITransportadoraRepository transportadoraRepository)
        {
            _transportadoraRepository = transportadoraRepository;
        }

        public async Task<int> Handle(CriarTransportadoraCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco(request.Endereco.Rua, request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.CEP);
            var cnpj = request.Cnpj; 

            var transportadora = new Transportadora(request.Nome, cnpj, request.Endereco.Rua,
                request.Endereco.Cidade,
                request.Endereco.Estado,
                request.Endereco.CEP);

            return await _transportadoraRepository.CriarAsync(transportadora);
        }
    }
}
