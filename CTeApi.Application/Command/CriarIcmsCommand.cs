using CTe.Application.Handler;
using CTe.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Command
{
    public class CriarIcmsCommand : IRequest<int>
    {
        public string UfOrigem { get; set; }
        public string UfDestino { get; set; }
        public int Aliquota { get; set; }

        public CriarIcmsCommand(string ufOrigem, string ufDestino, int aliquota)
        {
            if (string.IsNullOrWhiteSpace(ufOrigem))
                throw new CommandValidationException("UF de origem não pode ser vazia.");

            if (string.IsNullOrWhiteSpace(ufDestino))
                throw new CommandValidationException("UF de destino não pode ser vazia.");

            if (aliquota <= 0)
                throw new CommandValidationException("A alíquota deve ser um valor positivo.");

            UfOrigem = ufOrigem.ToUpper();
            UfDestino = ufDestino.ToUpper();
            Aliquota = aliquota;
        }
    }
}
