using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    [Table("Carona")]
    public class Carona
    {
        [Column("CaronaId")]
        [Display(Name = "Código da Carona")]
        public int CaronaId { get; set; }
     
        [Column("CaronaHorario")]
        [Display(Name = "Horário da Carona")]
        public DateTime CaronaHorario { get; set; }

        [Column("CaronaVeiculo")]
        [Display(Name = "Veículo da Carona")]
        public string CaronaVeiculo { get; set; } = string.Empty;

        [Column("CaronaVagas")]
        [Display(Name = "Vagas disponíveis")]
        public string CaronaVagas { get; set; } = string.Empty;

        [Column("CaronaOrigem")]
        [Display(Name = "Origem do Local")]
        public string CaronaOrigem { get; set; } = string.Empty;

        [Column("CaronaDestino")]
        [Display(Name = "Destino")]
        public string CaronaDestino { get; set; } = string.Empty;

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [ForeignKey("CaronaTipoId")]
        public int CaronaTipoId { get; set; }
        public CaronaTipo? CaronaTipo { get; set; }

       


    }
}
