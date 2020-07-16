using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeguradoraApi.ViewModel
{
	public class SeguradosViewModel
    {
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
           
    }    
}
