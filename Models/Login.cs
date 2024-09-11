using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Login
    {
        [Column("LoginId")]
        [Display(Name = "Código do Login")]

        public int LoginId { get; set; }

        [Column("LoginEmail")]
        [Display(Name = "E-mail")]

        public string LoginEmail { get; set; } = string.Empty;

        [Column("LoginSenha")]
        [Display(Name = "Senha")]

        public string LoginSenha { get; set; } = string.Empty;
    }
}
