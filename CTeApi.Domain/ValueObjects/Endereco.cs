using CTe.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Domain.ValueObjects
{
    public class Endereco
    {
        public string Rua { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }

        private Endereco() { }

        public Endereco(string rua, string cidade, string estado, string cep)
        {
            if (string.IsNullOrWhiteSpace(rua))
                throw new BusinessException("A rua não pode estar vazia.");

            if (string.IsNullOrWhiteSpace(cidade))
                throw new BusinessException("A cidade não pode estar vazia.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new BusinessException("O estado não pode estar vazio.");

            if (string.IsNullOrWhiteSpace(cep))
                throw new BusinessException("O CEP não pode estar vazio.");

            Rua = rua;
            Cidade = cidade;
            Estado = estado.ToUpper(); 
            Cep = cep;
        }
    }

}
