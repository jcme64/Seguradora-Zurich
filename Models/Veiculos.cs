using System;

namespace SeguradoraApi.Models
{
	public partial class Veiculos
	{
		public int IdVeiculo { get; set; }
		public string MarcaVeiculo { get; set; }
		public string ModeloVeiculo { get; set; }
		public string CorVeiculo { get; set; }
		public string Placa { get; set; }
		public string AnoVeiculo { get; set; }
		public string Renavam { get; set; }
		public decimal ValorVeiculo { get; set; }
	}
}
