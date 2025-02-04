using CTe.Application.Command;
using CTe.Repository.Interface;
using CTe.Domain.Domain;
using MediatR;


namespace CTe.Application.Handler
{
    public class CriarIcmsHandler : IRequestHandler<CriarIcmsCommand, int>
    {
        private readonly IIcmsRepository _icmsRepository;

        public CriarIcmsHandler(IIcmsRepository icmsRepository)
        {
            _icmsRepository = icmsRepository;
        }

        public async Task<int> Handle(CriarIcmsCommand command, CancellationToken cancellationToken)
        {
            var icmsAliquota = new IcmsAliquota(command.UfDestino,
                command.UfOrigem,
                command.Aliquota);

            return await _icmsRepository.InserirAsync(icmsAliquota);
        }
    }
}
