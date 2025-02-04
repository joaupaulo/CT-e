using CTe.Domain.Domain;
using MediatR;

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
