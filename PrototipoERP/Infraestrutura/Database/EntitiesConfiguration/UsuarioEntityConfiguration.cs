using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrototipoERP.Infraestrutura.Database.EntitiesConfiguration
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(p => p.Id).HasName("id");
            builder.HasIndex(p => p.Id);
            builder.HasIndex(p => new { p.Nome, p.Senha});

            builder.Property(p => p.Id).
                HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(p => p.Senha)
                .HasColumnName("senha")
                .HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}