using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class OfertarCarona
    {
        [Column("OfertarCaronaId")]
        [Display(Name = "Código do OfertarCarona")]

        public int OfertarCaronaId { get; set; }

        [Column("OfertarCaronaPeriodo")]
        [Display(Name = "Período do Dia")]

        public string OfertarCaronaPeriodo { get; set; } = string.Empty;

        [Column("OfertarCaronaHorário")]
        [Display(Name = "Horário da Oferta da Carona")]

        public DateTime OfertarCaronaHorário { get; set; }

        [Column("OfertarCaronaEndereço")]
        [Display(Name = "Endereço da Carona")]

        public string OfertarCaronaEndereço { get; set; } = string.Empty;

        [Column("OfertarCaronaVagas")]
        [Display(Name = "Vagas Disponíveis")]

        public string OfertarCaronaVagas { get; set; } = string.Empty;

        [Column("OfertarCaronaVeiculo")]
        [Display(Name = "Veiculo da Carona")]

        public string OfertarCaronaVeiculo { get; set; } = string.Empty;

    }
}
