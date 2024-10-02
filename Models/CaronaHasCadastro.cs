using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    [Table("CaronaHasCadastro")]
    public class CaronaHasCadastro
    {
        [Column("CaronaHasCadastroId")]
        [Display(Name = "Código da CaronaHasCadastro")]

        public int CaronaHasCadastroId { get; set; }

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [ForeignKey("CaronaId")]
        public int CaronaId { get; set; }
        public Carona? Carona { get; set; }
    }
}
