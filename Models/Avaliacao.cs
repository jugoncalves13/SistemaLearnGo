using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Avaliacao
    {

        [Column("AvaliacaoId")]
        [Display(Name = "Código da Avaliação")]

        public int AvaliacaoId { get; set; }
        
        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [ForeignKey("PerfilId")]
        public int PerfilId { get; set; }
        public Perfil? Perfil { get; set; }

        public string AvaliacaoComentario { get; set; } = string.Empty;

    }
}
