using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    public class Cadastro
    {
        [Column("CadastroId")]
        [Display(Name = "Código do Cadastro")]

        public int CadastroId { get; set; }

        [Column("CadastroNomeCompleto")]
        [Display(Name = "Nome Completo")]

        public string CadastroNomeCompleto { get; set; } = string.Empty;

        [Column("CadastroDataNascimento")]
        [Display(Name = "Data de Nascimento")]

        public string CadastroDataNascimento { get; set; } = string.Empty;

        [Column("CadastroRm")]
        [Display(Name = "RM do Aluno")]

        public string CadastroRm { get; set; } = string.Empty;

        [Column("CadastroCurso")]
        [Display(Name = "Curso Da Faculdade")]

        public string CadastroCurso { get; set; } = string.Empty;

        [Column("CadastroEmail")]
        [Display(Name = "E-mail")]

        public string CadastroEmail { get; set; } = string.Empty;

        [Column("CadastroSenha")]
        [Display(Name = "Senha")]

        public string CadastroSenha { get; set; } = string.Empty;

        [Column("CadastroEndereço")]
        [Display(Name = "Endereço")]

        public string CadastroEndereço { get; set; } = string.Empty;

        [ForeignKey("FaculdadeId")]
        public int FaculdadeId { get; set; }
        public Faculdade? Faculdade { get; set; }
    }
}

 
