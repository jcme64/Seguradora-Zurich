using System;

namespace SeguradoraApi.Models
{
	public partial class Seguros
	{
		public int IdSeguro { get; set; }
		public int IdSegurado { get; set; }
		public int IdVeiculo { get; set; }
		public decimal TaxaRisco { get; set; }
		public decimal PremioRisco { get; set; }
		public decimal PremioPuro { get; set; }
		public decimal PremioComercial { get; set; }
		public decimal ValorSeguro { get; set; }
	}

	public partial class SegurosRequest
	{
		public int IdSeguro { get; set; }
		public int IdSegurado { get; set; }
		public Veiculos Veiculo { get; set; }
	}
}
