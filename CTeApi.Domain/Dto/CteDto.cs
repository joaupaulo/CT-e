
namespace CTe.Domain.Dto
{
    public class CteDto
    {
        public int id { get; set; }
        public string nome_transportadora { get; set; }
        public string cnpj_transportadora { get; set; }
        public string nome_motorista { get; set; }
        public string cpf_motorista { get; set; }
        public string telefone_motorista { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal peso_carga { get; set; }
        public int volume_carga { get; set; }
        public decimal valor_frete { get; set; }
        public decimal valor_icms { get; set; }
        public decimal valor_cte { get; set; }
    }

}
