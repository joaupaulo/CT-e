using CTe.Shared.Exceptions;


namespace CTe.Domain.Domain
{
    public class Carga
    {
        public decimal Peso { get; private set; }
        public decimal Volume { get; private set; }
        public decimal TarifaPorPeso { get; private set; }
        public decimal Pedagio { get; private set; }
        public decimal Carregamento { get; private set; }

        public Carga(decimal peso, decimal volume, decimal tarifaPorPeso, decimal pedagio, decimal carregamento)
        {
            Peso = peso;
            Volume = volume;
            TarifaPorPeso = tarifaPorPeso;
            Pedagio = pedagio;
            Carregamento = carregamento;

            if (peso <= 0) throw new BusinessException("Peso deve ser maior que zero.");
            if (volume <= 0) throw new BusinessException("Volume deve ser maior que zero.");
        }

        public decimal CalcularValorFrete()
        {
            return TarifaPorPeso * Peso + Pedagio + Carregamento;
        }
    }


}
