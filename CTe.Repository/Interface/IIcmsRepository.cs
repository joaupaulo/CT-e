using CTe.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Repository.Interface
{
    public interface IIcmsRepository
    {
        Task<int> InserirAsync(IcmsAliquota icms);
        Task<decimal> BuscarPorUfAsync(string ufOrigem, string ufDestino);
    }

}
