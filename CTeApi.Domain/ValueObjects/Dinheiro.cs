using CTe.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Domain.ValueObjects
{
    public class Dinheiro
    {
        public decimal Valor { get; private set; }

        private Dinheiro() { }

        public Dinheiro(decimal valor)
        {
            if (valor < 0) throw new BusinessException("O valor não pode ser negativo.");
            Valor = valor;
        }

        public override string ToString() => Valor.ToString("C");
    }
}
