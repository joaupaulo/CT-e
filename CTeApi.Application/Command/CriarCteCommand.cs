using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Shared.Extensions;
using CTe.Domain.ValueObjects;
using MediatR;

namespace CTe.Application.Command
{
    public class CriarCteCommand : IRequest<int>
    {
        public int TransportadoraId { get; set; }
        public int MotoristaId { get; set; }
        public EnderecoDto Origem { get; set; }
        public EnderecoDto Destino { get; set; }
        public Carga Carga { get; set; }


        public Result Validate()
        {
            var errors = new List<string>();

            if (TransportadoraId <= 0)
                errors.Add("TransportadoraId deve ser maior que 0.");

            if (MotoristaId <= 0)
                errors.Add("MotoristaId deve ser maior que 0.");

            if (Origem == null)
                errors.Add("Origem não pode ser nula.");

            if (Destino == null)
                errors.Add("Destino não pode ser nulo.");

            if (Carga == null)
                errors.Add("Carga não pode ser nula.");

            return errors.Any() ? Result.Fail(errors) : Result.Ok();
        }
    }

    public class EnderecoDto
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
