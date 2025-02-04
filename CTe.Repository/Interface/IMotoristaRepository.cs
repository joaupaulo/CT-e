using CTe.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Repository.Interface
{
    public interface IMotoristaRepository
    {
        Task<Motorista> ObterPorIdAsync(int id);
        Task<int> CriarAsync(Motorista motorista);

    }
}
