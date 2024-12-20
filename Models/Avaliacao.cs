﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLearnGo.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {

        [Column("AvaliacaoId")]
        [Display(Name = "Código da Avaliação")]

        public int AvaliacaoId { get; set; }
        
        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        public Cadastro? Cadastro { get; set; }

        [ForeignKey("CaronaId")]
        public int CaronaId { get; set; }
        public Carona? Carona { get; set; }

        public string AvaliacaoComentario { get; set; } = string.Empty;
    }
}
