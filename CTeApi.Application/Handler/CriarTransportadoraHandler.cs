using CTe.Application.Command;
using CTe.Domain.Domain;
using CTe.Repository.Interface;
using MediatR;


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
            var endereco = new Endereco(request.Endereco.Rua, request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep);
            var cnpj = request.Cnpj; 

            var transportadora = new Transportadora(request.Nome, cnpj, request.Endereco.Rua,
                request.Endereco.Cidade,
                request.Endereco.Estado,
                request.Endereco.Cep);

            return await _transportadoraRepository.CriarAsync(transportadora);
        }
    }
}
