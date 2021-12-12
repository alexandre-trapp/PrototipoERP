using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface IEntityDao<T> where T : Entity
    {
        public Task Create(Entity entity);
        public Task Update(Entity entity);
        public Task<Entity> GetById(long id);
        public Task<bool> Exists(long id);
        public Task<IEnumerable<Entity>> GetAll();
    }
}
