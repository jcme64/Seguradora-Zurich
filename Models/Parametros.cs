using System;

namespace SeguradoraApi.Models
{
	public partial class Parametros
	{
		public int IdParametro { get; set; }
		public decimal MargemSeguranca { get; set; }
		public decimal Lucro { get; set; }
	}
}
