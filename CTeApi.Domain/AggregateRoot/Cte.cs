using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Domain.ValueObjects;

namespace CTe.Domain.AggregateRoot
{
    public class Cte
    {
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
            Transportadora = transportadora ?? throw new ArgumentNullException(nameof(transportadora));
            Motorista = motorista ?? throw new ArgumentNullException(nameof(motorista));
            Origem = origem ?? throw new ArgumentNullException(nameof(origem));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            Carga = carga ?? throw new ArgumentNullException(nameof(carga));

            decimal valorFrete = carga.CalcularValorFrete();

            var baseCalculoICMS = valorFrete / (1 - aliquotaICMS / 100);
            ValorICMS = new Dinheiro(baseCalculoICMS * (aliquotaICMS / 100));

            ValorFrete = new Dinheiro(valorFrete);
            ValotTotalCte = new Dinheiro(valorFrete + ValorICMS.Valor);

        }
    }
}
