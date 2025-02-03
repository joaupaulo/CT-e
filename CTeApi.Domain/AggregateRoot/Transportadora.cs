using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Domain.ValueObjects;

namespace CTe.Domain.AggregateRoot
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
            Nome = string.IsNullOrWhiteSpace(nome) ? throw new ArgumentNullException(nameof(nome), "O nome da transportadora é obrigatório.") : nome;
            Cnpj = string.IsNullOrWhiteSpace(cnpj) ? throw new ArgumentNullException(nameof(cnpj), "O CNPJ da transportadora é obrigatório.") : cnpj;
            EnderecoRua = string.IsNullOrWhiteSpace(enderecoRua) ? throw new ArgumentNullException(nameof(enderecoRua), "O endereço (rua) é obrigatório.") : enderecoRua;
            EnderecoCidade = string.IsNullOrWhiteSpace(enderecoCidade) ? throw new ArgumentNullException(nameof(enderecoCidade), "A cidade do endereço é obrigatória.") : enderecoCidade;
            EnderecoEstado = string.IsNullOrWhiteSpace(enderecoEstado) ? throw new ArgumentNullException(nameof(enderecoEstado), "O estado do endereço é obrigatório.") : enderecoEstado;
            EnderecoCep = string.IsNullOrWhiteSpace(enderecoCep) ? throw new ArgumentNullException(nameof(enderecoCep), "O CEP do endereço é obrigatório.") : enderecoCep;
        }

        private Transportadora() { }
    }

}
