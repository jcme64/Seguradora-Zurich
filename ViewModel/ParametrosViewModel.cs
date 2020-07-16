using System.ComponentModel.DataAnnotations.Schema;

namespace SeguradoraApi.ViewModel
{
	public partial class ParametrosViewModel
	{
		[Column("id_parametro")]
		public int IdParametro { get; set; }
		[Column("margem_seguranca")]
		public decimal MargemSeguranca { get; set; }
		[Column("lucro")]
		public decimal Lucro { get; set; }
	}
}
