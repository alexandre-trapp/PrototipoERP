using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface IUsuarioDao<T> : IEntityDao<T> where T : Entidades.Entity
    {
        Task<Usuario> ObterUsuarioPorNomeSenha(string nome, string senha);
        Task<long> ObterUsuarioIdPorNomeSenha(string nome, string senha);
    }
}
