using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrototipoERP.Infraestrutura.Database.EntitiesConfiguration
{
    public class LembreteEntityConfiguration : IEntityTypeConfiguration<Lembrete>
    {
        public void Configure(EntityTypeBuilder<Lembrete> builder)
        {
            builder.ToTable("lembretes");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.HasIndex(p => p.UsuarioId);
            
            builder.Property(p => p.TextoLembrete).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(p => p.DataHora).HasColumnType("DATETIME").IsRequired();

            builder
               .HasOne(p => p.Usuario)
               .WithMany(usuario => usuario.Lembretes)
               .HasForeignKey(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}