using CTe.Application.Command;
using CTe.Repository.Interface;
using CTe.Domain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Handler
{
    public class CriarIcmsHandler : IRequestHandler<CriarIcmsCommand, decimal>
    {
        private readonly IIcmsRepository _icmsRepository;

        public CriarIcmsHandler(IIcmsRepository icmsRepository)
        {
            _icmsRepository = icmsRepository;
        }

        public async Task<decimal> Handle(CriarIcmsCommand command, CancellationToken cancellationToken)
        {
            var icmsAliquota = new IcmsAliquota(command.UfDestino,
                command.UfOrigem,
                command.Aliquota);

            return await _icmsRepository.InserirAsync(icmsAliquota);
        }
    }
}
