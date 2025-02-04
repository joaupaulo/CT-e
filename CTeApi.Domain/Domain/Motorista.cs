
using CTe.Shared.Exceptions;

namespace CTe.Domain.Domain
{
    public class Motorista
    {
        public int Id { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Cnh { get; private set; }
        public string Telefone { get; private set; }

        public Motorista(string nome, string cpf, string telefone, string cnh)
        {
            Nome = nome ?? throw new BusinessException(nameof(nome));
            Cpf = cpf ?? throw new BusinessException(nameof(cpf));
            Cnh = cnh ?? throw new BusinessException(nameof(cnh));
            Telefone = telefone ?? throw new BusinessException(nameof(telefone));
        }
    }
}
