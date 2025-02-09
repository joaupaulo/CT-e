﻿using CTe.Shared.Extensions;
using MediatR;
using CTe.Domain.Domain;

namespace CTe.Application.Command
{
    public class CriarCteCommand : IRequest<int>
    {
        public int TransportadoraId { get; set; }
        public int MotoristaId { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
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
}
