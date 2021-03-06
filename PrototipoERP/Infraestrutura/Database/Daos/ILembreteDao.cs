using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface ILembreteDao<T> : IEntityDao<T> where T : Entidades.Entity
    {
        public Task<IEnumerable<Lembrete>> ListarLembretesPorUsuario(long usuarioId);
    }
}
