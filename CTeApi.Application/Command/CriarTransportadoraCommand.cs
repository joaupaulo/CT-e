using CTe.Domain.Domain;
using CTe.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Command
{
    public class CriarTransportadoraCommand : IRequest<int>
    {
        public string Nome { get; }
        public string Cnpj { get; }
        public Endereco Endereco { get; }

        public CriarTransportadoraCommand(string nome, string cnpj, Endereco endereco)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(nome))
                errors.Add("O nome da transportadora é obrigatório.");

            if (string.IsNullOrWhiteSpace(cnpj))
                errors.Add("O CNPJ é obrigatório.");

            if (!ValidarCnpj(cnpj))
                errors.Add("O CNPJ informado é inválido.");

            if (endereco == null)
                errors.Add("O endereço da transportadora é obrigatório.");

            if (string.IsNullOrWhiteSpace(endereco.Rua))
                errors.Add("A rua é obrigatória.");

            if (string.IsNullOrWhiteSpace(endereco.Cidade))
                errors.Add("A cidade é obrigatória.");

            if (string.IsNullOrWhiteSpace(endereco.Estado))
                errors.Add("O estado é obrigatório.");

            if (string.IsNullOrWhiteSpace(endereco.Cep))
                errors.Add("O CEP é obrigatório.");

            if (errors.Any())
            {
                throw new CommandValidationException(string.Join(", ", errors));
            }

            Nome = nome;
            Cnpj = cnpj;
            Endereco = endereco;
        }

        private bool ValidarCnpj(string cnpj)
        {
            return cnpj.Length == 14 && cnpj.All(char.IsDigit);
        }
    }
}
