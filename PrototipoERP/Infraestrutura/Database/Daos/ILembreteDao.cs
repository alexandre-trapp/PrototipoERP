using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface ILembreteDao : ILembreteDao
    {
        public Task<IEnumerable<Lembrete>> ListarLembretesPorUsuario(long usuarioId);
    }
}
