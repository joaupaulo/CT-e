using CTe.Domain.Domain;
using MediatR;


namespace CTe.Application.Queries
{
    public class ObterMotoristaPorIdQuery : IRequest<Motorista>
    {
        public int Id { get; }

        public ObterMotoristaPorIdQuery(int id)
        {
            Id = id;
        }
    }

}
