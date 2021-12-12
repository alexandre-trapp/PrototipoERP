using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;
using PrototipoERP.Configuracoes.Database.EntitiesConfiguration;

namespace PrototipoERP.Configuracoes.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionDb.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsuarioEntityConfiguration().Configure(modelBuilder.Entity<Usuario>());
            new LembreteEntityConfiguration().Configure(modelBuilder.Entity<Lembrete>());
        }
    }
}
