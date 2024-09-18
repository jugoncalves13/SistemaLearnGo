using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Perfil
    {
        [Column("PerfilId")]
        [Display(Name = "Código do Perfil")]

        public int PerfilId { get; set; }

        [Column("PerfilFoto")]
        [Display(Name = "Foto do Perfil")]

        public string PerfilFoto { get; set; } = string.Empty;

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [NotMapped]
        public string PerfilCadastroNome { get; set; } = string.Empty;

    }
}
