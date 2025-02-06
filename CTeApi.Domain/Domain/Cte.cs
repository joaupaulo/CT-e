

using CTe.Shared.Exceptions;

namespace CTe.Domain.Domain
{
    public class Cte
    {
        private const decimal BASE_CALCULO = 1m;
        private const decimal PERCENT_DIVISOR = 100m;


        public int Id { get; private set; }
        public Transportadora Transportadora { get; private set; }
        public Motorista Motorista { get; private set; }
        public Endereco Origem { get; private set; }
        public Endereco Destino { get; private set; }
        public Carga Carga { get; private set; }
        public Dinheiro ValorFrete { get; private set; }
        public Dinheiro ValorICMS { get; private set; }
        public Dinheiro ValotTotalCte { get; private set; }
        public Cte() { }
        public Cte(Transportadora transportadora, Motorista motorista, Endereco origem, Endereco destino, Carga carga, decimal aliquotaICMS)

        {
            Transportadora = transportadora ?? throw new BusinessException(nameof(transportadora));
            Motorista = motorista ?? throw new BusinessException(nameof(motorista));
            Origem = origem ?? throw new BusinessException(nameof(origem));
            Destino = destino ?? throw new BusinessException(nameof(destino));
            Carga = carga ?? throw new BusinessException(nameof(carga));

            decimal valorFrete = carga.CalcularValorFrete();

            var baseCalculoICMS = valorFrete / (BASE_CALCULO - aliquotaICMS / PERCENT_DIVISOR);
            ValorICMS = new Dinheiro(baseCalculoICMS * (aliquotaICMS / PERCENT_DIVISOR));

            ValorFrete = new Dinheiro(valorFrete);
            ValotTotalCte = new Dinheiro(valorFrete + ValorICMS.Valor);

        }
    }
}
