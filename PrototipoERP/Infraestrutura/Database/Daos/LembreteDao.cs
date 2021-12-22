using Dapper;
using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;
using PrototipoERP.Infraestrutura.Database.Dtos;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public class LembreteDao : ILembreteDao<Lembrete>
    {
        public ApplicationDbContext _dbContext { get; }
        public LembreteDao(ApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Create(Entidades.Entity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Entidades.Entity entity)
        {
            if (entity.Id <= 0)
                throw new OperationCanceledException($"Id do lembrete={entity.Id} inválido para atualização na base de dados.");

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entidades.Entity> GetById(long id)
        {
            var lembrete = await _dbContext.Lembretes.FindAsync(id);
            if (lembrete == null)
                throw new OperationCanceledException($"Lembrete com id {id} não encontrado na base de dados");

            return lembrete;
        }

        public async Task<IEnumerable<Entidades.Entity>> GetAll()
        {
            var lembretes = await _dbContext.Database.GetDbConnection()
                            .QueryAsync<TodosLembretesDto>(
                                @"SELECT a.id Id,
                                         a.usuario_id UsuarioId, 
                                         a.texto Texto,
                                         a.data_hora DataHora
                                         b.nome Usuario
                                  FROM lembretes a
                                       INNER JOIN usuarios b ON(b.id = a.usuario_id)");

            if (lembretes == null)
                return new List<TodosLembretesDto>();

            return lembretes;
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
