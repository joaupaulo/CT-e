using CTe.Domain.ValueObjects;

namespace CTe.Domain.AggregateRoot
{
    public class Motorista
    {
        public int Id { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Cnh { get; private set; }
        public string Telefone { get; private set; }
        private Motorista() { }

        public Motorista(string nome, string cpf, string telefone, string cnh)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Cnh = cnh ?? throw new ArgumentNullException(nameof(cnh));
            Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
        }
    }
}
