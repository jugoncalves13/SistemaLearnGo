using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Avaliacao
    {

        [Column("AvaliacaoId")]
        [Display(Name = "Código da Avaliação")]

        public int AvaliacaoId { get; set; }

        [Column("AvaliacaoQuemAvaliou")]
        [Display(Name = "Pessoa que Avaliou")]

        public string AvaliacaoQuemAvaliou { get; set; } = string.Empty;

        [Column("AvaliacaoAvaliado")]
        [Display(Name = "Pessoa que foi Avaliado")]

        public string AvaliacaoAvaliado { get; set; } = string.Empty;

        [Column("AvaliacaoComentario")]
        [Display(Name = "Comentário")]

        public string AvaliacaoComentario { get; set; } = string.Empty;

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

    }
}
