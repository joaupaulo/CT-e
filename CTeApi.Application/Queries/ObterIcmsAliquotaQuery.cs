using MediatR;

namespace CTe.Application.Queries
{
    public class ObterIcmsAliquotaQuery : IRequest<decimal>
    {
        public string UfOrigem { get; }
        public string UfDestino { get; }

        public ObterIcmsAliquotaQuery(string ufOrigem, string ufDestino)
        {
            if (string.IsNullOrWhiteSpace(ufOrigem))
                throw new ArgumentNullException("UF de origem não pode ser vazia.", nameof(ufOrigem));

            if (string.IsNullOrWhiteSpace(ufDestino))
                throw new ArgumentNullException("UF de destino não pode ser vazia.", nameof(ufDestino));

            UfOrigem = ufOrigem.ToUpper();
            UfDestino = ufDestino.ToUpper();
        }
    }
}
