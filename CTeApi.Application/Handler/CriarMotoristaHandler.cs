using CTe.Application.Command;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using MediatR;


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
