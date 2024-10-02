using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLearnGo.Models
{
    [Table("CaronaTipo")]
    public class CaronaTipo
    {
        [Column("CaronaTipoId")]
        [Display(Name = "Código da CaronaTipo")]

        public int CaronaTipoId { get; set; }

        [Column("CaronaTipoDescricao")]
        [Display(Name = "Descrição da  Carona")]

        public string CaronaTipoDescricao { get; set; } = string.Empty;

        
    }
}
