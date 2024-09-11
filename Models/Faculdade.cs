using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Faculdade
    {
        [Column("FaculdadeId")]
        [Display(Name = "Código da Faculdade")]

        public int FaculdadeId { get; set; }

        [Column("FaculdadeNome")]
        [Display(Name = "Nome da Faculdade")]

        public string FaculdadeNome { get; set; } = string.Empty;

        [Column("FaculdadeCidade")]
        [Display(Name = "Cidade da Faculdade")]

        public string FaculdadeCidade { get; set; } = string.Empty;
    }
}
