using System.ComponentModel.DataAnnotations;

namespace ApiVotacao.Models
{
    public class Voto
    {
        [Required]
        public string RA { get; set; } = string.Empty;

        public DateTime DataVoto { get; set; } = DateTime.Now;

        [Required]
        [Range(10, 99)]
        public int NumeroCandidato { get; set; }
    }
}