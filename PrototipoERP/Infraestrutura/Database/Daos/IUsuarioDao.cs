using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface IUsuarioDao<T> : IEntityDao<T> where T : Entity
    {
        public Task<Usuario> ObterUsuarioPorNomeSenha(string nome, string senha);
    }
}
