using CTe.Repository.Interface;
using CTe.Domain.AggregateRoot;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Text;
using CTe.Domain.Dto;

namespace CTe.Repository
{
    public class CteRepository : BaseRepository, ICteRepository
    {

        public CteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> CriarCteAsync(Cte cte)
        {

            var origemBuilder = new StringBuilder()
                .Append(cte.Origem.Rua).Append(", ")
                .Append(cte.Origem.Cidade).Append(" - ")
                .Append(cte.Origem.Estado);

            var destinoBuilder = new StringBuilder()
                .Append(cte.Destino.Rua).Append(", ")
                .Append(cte.Destino.Cidade).Append(" - ")
                .Append(cte.Destino.Estado);

            var sql = @"
            INSERT INTO Cte (
                nome_transportadora, cnpj_transportadora, 
                nome_motorista, cpf_motorista, telefone_motorista, 
                origem, destino, 
                peso_carga, volume_carga, 
                valor_frete, valor_icms, valor_cte
            ) VALUES (
                @NomeTransportadora, @CnpjTransportadora, 
                @NomeMotorista, @CpfMotorista, @TelefoneMotorista, 
                @Origem, @Destino, 
                @PesoCarga, @VolumeCarga, 
                @ValorFrete, @ValorICMS, @ValorTotalCte
            ) RETURNING id;
        ";

            return await ExecuteScalarAsync<int>(sql, new
            {
                NomeTransportadora = cte.Transportadora.Nome,
                CnpjTransportadora = cte.Transportadora.Cnpj,
                NomeMotorista = cte.Motorista.Nome,
                CpfMotorista = cte.Motorista.Cpf,
                TelefoneMotorista = cte.Motorista.Telefone,
                Origem = origemBuilder.ToString(),
                Destino = destinoBuilder.ToString(),
                PesoCarga = cte.Carga.Peso,
                VolumeCarga = cte.Carga.Volume,
                ValorFrete = cte.ValorFrete.Valor,
                ValorICMS = cte.ValorICMS.Valor,
                ValorTotalCte = cte.ValotTotalCte.Valor
            });
        }

        public async Task<CteDto> ObterPorIdAsync(int id)
        {
            var sql = "SELECT * FROM Cte WHERE Id = @Id";

            return await ExecuteQueryAsync<CteDto>(sql, new { Id = id });
        }
    }
}
