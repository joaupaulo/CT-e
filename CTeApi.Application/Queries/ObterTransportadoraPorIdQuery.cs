using CTe.Domain.AggregateRoot;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Queries
{
    public class ObterTransportadoraPorIdQuery : IRequest<Transportadora>
    {
        public int Id { get; }

        public ObterTransportadoraPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
