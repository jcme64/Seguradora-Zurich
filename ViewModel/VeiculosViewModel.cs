using System.ComponentModel.DataAnnotations.Schema;

namespace SeguradoraApi.ViewModel
{
	public class VeiculosViewModel
    {
        [Column("id_veiculo")]
		public int IdVeiculo { get; set; }
		[Column("marca_veiculo")]
		public string MarcaVeiculo { get; set; }
		[Column("modelo_veiculo")]
		public string ModeloVeiculo { get; set; }
		[Column("cor_veiculo")]
		public string CorVeiculo { get; set; }
		[Column("placa")]
		public string Placa { get; set; }
		[Column("ano_veiculo")]
		public string AnoVeiculo { get; set; }
		[Column("valor_veiculo")]
		public decimal ValorVeiculo { get; set; }
		[Column("renavam")]
		public string Renavam { get; set; }
	}

    
}
