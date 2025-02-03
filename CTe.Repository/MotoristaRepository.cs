using CTe.Repository.Interface;
using CTe.Domain.AggregateRoot;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Repository
{
    public class MotoristaRepository : BaseRepository, IMotoristaRepository
    {
        private readonly string _connectionString;

        public MotoristaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> CriarAsync(Motorista motorista)
        {

            var sql = @"
                INSERT INTO Motoristas (Nome, Cpf, Cnh, Telefone) 
                VALUES (@Nome, @Cpf, @Cnh, @Telefone)
                RETURNING Id;
                ";

            return await ExecuteScalarAsync<int>(sql, new
            {
                Nome = motorista.Nome,
                Cpf = motorista.Cpf,
                Cnh = motorista.Cnh,
                Telefone = motorista.Telefone
            });
        }

        public async Task<Motorista> ObterPorIdAsync(int id)
        {
                var sql = "SELECT Id, Nome, Cpf, Telefone FROM motoristas WHERE Id = @Id";
                return await ExecuteQueryAsync<Motorista>(sql, new { Id = id });
        }
    }

}
