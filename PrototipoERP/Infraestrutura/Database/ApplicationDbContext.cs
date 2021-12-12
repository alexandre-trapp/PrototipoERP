using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;
using PrototipoERP.Infraestrutura.Database.EntitiesConfiguration;

namespace PrototipoERP.Infraestrutura.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL(ConnectionDb.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsuarioEntityConfiguration().Configure(modelBuilder.Entity<Usuario>());
            new LembreteEntityConfiguration().Configure(modelBuilder.Entity<Lembrete>());
        }
    }
}
