using CTe.Shared.Exceptions;
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
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }

        protected async Task<T> ExecuteQueryAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex) 
            {
                throw new DatabaseAccessException($"Erro ao executar consulta SQL: {sql}", ex);
            }
        }
        protected async Task<T> ExecuteScalarAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteScalarAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex) 
            {
                throw new DatabaseAccessException($"Erro ao executar comando SQL: {sql}", ex);
            }
        }
    }

}
