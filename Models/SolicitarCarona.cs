using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class SolicitarCarona
    {
        [Column("SolicitarCaronaId")]
        [Display(Name = "Código do SolicitarCarona")]

        public int SolicitarCaronaId { get; set; }

        [Column("SolicitarCaronaNome")]
        [Display(Name = "Nome do Usuário")]

        public string SolicitarCaronaNome { get; set; } = string.Empty;

        [Column("SolicitarCaronaHorário")]
        [Display(Name = "Horário da Carona")]

        public DateTime SolicitarCaronaHorário { get; set; }

        [Column("SolicitarCaronaEndereço")]
        [Display(Name = "Endereço da Carona")]

        public string SolicitarCaronaEndereço { get; set; } = string.Empty;

        [ForeignKey("FaculdadeId")]
        public int FaculdadeId { get; set; }
        public Faculdade? Faculdade { get; set; }


    }
}
