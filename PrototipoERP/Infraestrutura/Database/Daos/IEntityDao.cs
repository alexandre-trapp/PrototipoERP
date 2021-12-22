using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface IEntityDao<T> where T : Entidades.Entity
    {
        public Task Create(Entidades.Entity entity);
        public Task Update(Entidades.Entity entity);
        public Task<Entidades.Entity> GetById(long id);
        public Task<bool> Exists(long id);
        public Task<IEnumerable<Entidades.Entity>> GetAll();
    }
}
