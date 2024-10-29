using Microsoft.EntityFrameworkCore;

namespace SistemaLearnGo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cadastro>? Cadastro { get; set; }
        public DbSet<Faculdade>? Faculdade { get; set; }
        public DbSet<CaronaHasCadastro>? CaronaHasCadastro { get; set; }
        public DbSet<Carona>? Carona { get; set; }
        public DbSet<Avaliacao>? Avaliacao { get; set; }

    }
}
