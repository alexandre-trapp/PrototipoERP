using PrototipoERP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PrototipoERP.Infraestrutura.Database.Daos
{
    public class UsuarioDao : IUsuarioDao<Usuario>
    {
        public ApplicationDbContext _dbContext { get; }
        public UsuarioDao(ApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Create(Entity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Entity entity)
        {
            if (entity.Id == null || entity.Id <= 0)
                throw new OperationCanceledException($"Id do lembrete={entity.Id} inválido para atualização na base de dados.");

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entity> GetById(long id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new OperationCanceledException($"Usuário com id {id} não encontrado na base de dados");

            return usuario;
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            if (usuarios == null)
                return new List<Usuario>();

            return usuarios;
        }

        public async Task<bool> Exists(long id) =>
            await _dbContext.Usuarios.AnyAsync(x => x.Id == id);

        public async Task<Usuario> ObterUsuarioPorNomeSenha(string nome, string senha) =>
            await _dbContext.Usuarios
                .FirstOrDefaultAsync(x => 
                    x.Nome == nome && 
                    x.Senha == senha);
    }
}
