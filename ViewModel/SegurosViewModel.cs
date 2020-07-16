using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeguradoraApi.Models
{
	public partial class SegurosViewModel
	{
		[Column("id_seguro")]
		public int IdSeguro { get; set; }
		[Column("taxa_risco")]
		public decimal TaxaRisco { get; set; }
		[Column("Premio_risco")]
		public decimal PremioRisco { get; set; }
		[Column("premio_puro")]
		public decimal PremioPuro { get; set; }
		[Column("premio_comercial")]
		public decimal PremioComercial { get; set; }
		[Column("Valor_seguro")]
		public decimal ValorSeguro { get; set; }

        #region Segurado
        [Column("id_segurado")]
        public int IdSegurado { get; set; }
        [Column("nome_segurado")]
        public string NomeSegurado { get; set; }
        [Column("dt_nascimento")]
        public DateTime DtNascimento { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("genero")]
        public string Genero { get; set; }
        public string CpfFormatado
        {
            get
            {
                if (Cpf != null)
                {
                    MaskedTextProvider mascara = new MaskedTextProvider("000\\.000\\.000\\-00");
                    mascara.Set(Cpf);
                    return mascara.ToString();

                }
                else
                    return "";
            }
        }
        public int Idade
        {
            get
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                if (DtNascimento != DateTime.MinValue)
                {
                    TimeSpan span = DateTime.Now - DtNascimento;
                    // Because we start at year 1 for the Gregorian
                    // calendar, we must subtract a year here.
                    return (zeroTime + span).Year;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion Segurado

        #region Veiculo
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
        #endregion Veiculo

    }

    public partial class MediasViewModel
    {
        [Column("taxa_risco")]
        public decimal TaxaRisco { get; set; }
        [Column("premio_risco")]
        public decimal PremioRisco { get; set; }
        [Column("premio_puro")]
        public decimal PremioPuro { get; set; }
        [Column("premio_comercial")]
        public decimal PremioComercial { get; set; }
        [Column("Valor_seguro")]
        public decimal ValorSeguro { get; set; }
    }
}
