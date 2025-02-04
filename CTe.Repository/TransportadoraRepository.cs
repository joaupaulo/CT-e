using CTe.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTe.Domain.Domain;

namespace CTe.Repository
{
    public class TransportadoraRepository : BaseRepository, ITransportadoraRepository
    {
        private readonly string _connectionString;

        public TransportadoraRepository(IConfiguration configuration) : base(configuration) 
        {
        }

        public async Task<int> CriarAsync(Transportadora transportadora)
        {
          
                var sql = @"
    INSERT INTO Transportadora (Cnpj, Nome, EnderecoRua, EnderecoCidade, EnderecoEstado, EnderecoCep)
    VALUES (@Cnpj, @Nome, @EnderecoRua, @EnderecoCidade, @EnderecoEstado, @EnderecoCep)
    RETURNING Id;
    ";
                return await ExecuteScalarAsync<int>(sql, new
                {
                    Nome = transportadora.Nome,
                    Cnpj = transportadora.Cnpj,
                    EnderecoRua = transportadora.EnderecoRua,
                    EnderecoCidade = transportadora.EnderecoCidade,
                    EnderecoEstado = transportadora.EnderecoEstado,
                    EnderecoCep = transportadora.EnderecoCep
                });
            
        }

        public async Task<Transportadora> ObterPorIdAsync(int id)
        {
            
                var sql = @"
                    SELECT 
                        Id,
                        Nome, 
                        Cnpj, 
                        EnderecoRua, 
                        EnderecoCidade, 
                        EnderecoEstado, 
                        EnderecoCep
                    FROM Transportadora 
                    WHERE Id = @Id";

                return await ExecuteQueryAsync<Transportadora>(sql, new { Id = id });
            }
        
    }
}
