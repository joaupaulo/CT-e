using CTe.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Command
{
    public class CriarMotoristaCommand : IRequest<int>
    {
        public string Nome { get; }
        public string Cpf { get; }
        public string Telefone { get; }
        public string Cnh { get; set; }
        public CriarMotoristaCommand(string nome, string cpf, string telefone, string cnh)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(nome))
                errors.Add("O nome do motorista é obrigatório.");

            if (string.IsNullOrWhiteSpace(cpf))
                errors.Add("O CPF é obrigatório.");

            if (!ValidarCpf(cpf))
                errors.Add("O CPF informado é inválido.");
            if (string.IsNullOrWhiteSpace(cnh))
                errors.Add("O CNH informado é inválido.");

            if (string.IsNullOrWhiteSpace(telefone))
                errors.Add("O telefone é obrigatório.");

            if (errors.Any())
            {
                throw new CommandValidationException(string.Join(", ", errors));
            }

            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Cnh = cnh;
        }

        private bool ValidarCpf(string cpf)
        {
            return cpf.Length == 11 && cpf.All(char.IsDigit);
        }
    }
}
