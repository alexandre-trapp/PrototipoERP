using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public interface ILembreteDao
    {
        public Task Create(Entity entity);
        public Task Update(Entity entity);
        public Task<Entity> GetById(long id);
        public Task<IEnumerable<Entity>> GetAll();
    }
}
