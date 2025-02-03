using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Domain.AggregateRoot;
using CTe.Domain.Dto;

namespace CTe.Repository.Interface
{
    public interface ICteRepository
    {
        Task<int> CriarCteAsync(Cte cte);
        Task<CteDto> ObterPorIdAsync(int id);
    }
}
