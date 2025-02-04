using CTe.Shared.Exceptions;


namespace CTe.Domain.Domain
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
    }
}
