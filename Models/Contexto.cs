using Microsoft.EntityFrameworkCore;

namespace SistemaLearnGo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cadastro>? Cadastro { get; set; }
        public DbSet<Login>? Login { get; set; }
        public DbSet<Faculdade>? Faculdade { get; set; }
        public DbSet<SolicitarCarona>? SolicitarCarona { get; set; }
        public DbSet<OfertarCarona>? OfertarCarona { get; set; }
        public DbSet<Perfil>? Perfil { get; set; }
        public DbSet<Avaliacao>? Avaliacao { get; set; }

    }
}
