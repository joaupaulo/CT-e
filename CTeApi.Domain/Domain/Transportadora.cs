using CTe.Shared.Exceptions;

namespace CTe.Domain.Domain
{
    public class Transportadora
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string EnderecoRua { get; private set; }
        public string EnderecoCidade { get; private set; }
        public string EnderecoEstado { get; private set; }
        public string EnderecoCep { get; private set; }

        public Transportadora(string nome, string cnpj, string enderecoRua, string enderecoCidade, string enderecoEstado, string enderecoCep)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ? throw new BusinessException("O nome da transportadora é obrigatório.") : nome;
            Cnpj = string.IsNullOrWhiteSpace(cnpj) ? throw new BusinessException("O CNPJ da transportadora é obrigatório.") : cnpj;
            EnderecoRua = string.IsNullOrWhiteSpace(enderecoRua) ? throw new BusinessException( "O endereço (rua) é obrigatório.") : enderecoRua;
            EnderecoCidade = string.IsNullOrWhiteSpace(enderecoCidade) ? throw new BusinessException("A cidade do endereço é obrigatória.") : enderecoCidade;
            EnderecoEstado = string.IsNullOrWhiteSpace(enderecoEstado) ? throw new BusinessException("O estado do endereço é obrigatório.") : enderecoEstado;
            EnderecoCep = string.IsNullOrWhiteSpace(enderecoCep) ? throw new BusinessException("O CEP do endereço é obrigatório.") : enderecoCep;
        }
    }
}
