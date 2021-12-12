using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface ILembreteDao : IEntityDao
    {
        public Task<IEnumerable<Lembrete>> ListarLembretesPorUsuario(long usuarioId);
    }
}
