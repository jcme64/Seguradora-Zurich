using System;

namespace SeguradoraApi.Models
{
	public partial class Segurados
	{
		public int IdSegurado { get; set; }
		public string NomeSegurado { get; set; }
		public DateTime DtNascimento { get; set; }
		public string Cpf { get; set; }			
		public string Genero { get; set; }
	}
}
