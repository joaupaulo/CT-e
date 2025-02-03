using CTe.Domain.AggregateRoot;
using CTe.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Application.Queries
{
    public class ObterCtePorIdQuery : IRequest<CteDto>
    {
        public int Id { get; }

        public ObterCtePorIdQuery(int id)
        {
            Id = id;
        }
    }

}
