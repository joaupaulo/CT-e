using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Repository
{
    using CTe.Repository.Interface;
    using CTe.Domain.Domain;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Npgsql;
    using System.Data;
    using System.Threading.Tasks;

    public class IcmsRepository : BaseRepository, IIcmsRepository
    {
        public IcmsRepository(IConfiguration configuration) : base(configuration) 
        {
        }

        public async Task<int> InserirAsync(IcmsAliquota icms)
        {
            const string sql = @"
                INSERT INTO AliquotaICMS (UfOrigem, UfDestino, Aliquota)
                VALUES (@UfOrigem, @UfDestino, @Aliquota)
                RETURNING Id;
            ";

                return await ExecuteScalarAsync<int>(sql, new
                {
                    icms.UfOrigem,
                    icms.UfDestino,
                    icms.Aliquota
                });
        }

        public async Task<decimal> BuscarPorUfAsync(string ufOrigem, string ufDestino)
        {
           
                const string sql = @"
                SELECT Id, UfOrigem, UfDestino, Aliquota 
                FROM AliquotaICMS 
                WHERE UfOrigem = @UfOrigem AND UfDestino = @UfDestino
                LIMIT 1;
            ";

                return await ExecuteQueryAsync<decimal>(sql, new
                {
                    UfOrigem = ufOrigem.ToUpper(),
                    UfDestino = ufDestino.ToUpper()
                });
            }
        }
    }
