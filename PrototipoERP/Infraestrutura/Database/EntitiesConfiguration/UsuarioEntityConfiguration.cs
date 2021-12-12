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
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}