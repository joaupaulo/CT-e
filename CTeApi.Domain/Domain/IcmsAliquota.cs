using CTe.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Domain.Domain
{
    public class IcmsAliquota
    {
        public int Id { get; private set; }
        public string UfDestino { get; private set; }
        public string UfOrigem { get; private set; }
        public decimal Aliquota { get; private set; }

        public IcmsAliquota(string ufDestino, string ufOrigem, decimal aliquota)
        {
            UfDestino = ufDestino ?? throw new ArgumentNullException(nameof(ufDestino));
            UfOrigem = ufOrigem ?? throw new ArgumentNullException(nameof(ufOrigem));

            if (aliquota < 0 || aliquota > 100)
                throw new BusinessException("A alíquota deve estar entre 0 e 100.");

            Aliquota = aliquota;
        }
    }

}
