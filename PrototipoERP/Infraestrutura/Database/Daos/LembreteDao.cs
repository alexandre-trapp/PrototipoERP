using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public class LembreteDao : ILembreteDao<Entity>
    {
        public ApplicationDbContext _dbContext { get; }
        public LembreteDao(ApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Create(Entity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Entity entity)
        {
            if (entity.Id <= 0)
                throw new OperationCanceledException($"Id do lembrete={entity.Id} inválido para atualização na base de dados.");

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entity> GetById(long id)
        {
            var lembrete = await _dbContext.Lembretes.FindAsync(id);
            if (lembrete == null)
                throw new OperationCanceledException($"Lembrete com id {id} não encontrado na base de dados");

            return lembrete;
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            var usuarios = await _dbContext.Lembretes.ToListAsync();
            if (usuarios == null)
                return new List<Lembrete>();

            return usuarios;
        }

        public async Task<IEnumerable<Lembrete>> ListarLembretesPorUsuario(long usuarioId)
        {
            var lembretes = await _dbContext.Lembretes
                             .Where(x => x.UsuarioId == usuarioId)
                             .ToListAsync();

            if (lembretes == null)
                return new List<Lembrete>();

            return lembretes;
        }

        public async Task<bool> Exists(long id) =>
            await _dbContext.Lembretes.AnyAsync(x => x.Id == id);
    }
}
