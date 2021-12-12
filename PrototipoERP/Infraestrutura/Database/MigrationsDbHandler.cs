using Microsoft.EntityFrameworkCore;

namespace PrototipoERP.Infraestrutura.Database
{
    public static class MigrationsDbHandler
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
                Console.WriteLine("Atualizações de base de dados aplicadas com sucesso.");
            }
            else
                Console.WriteLine("Nenhuma atualização existente para aplicação na base de dados.");
        }
    }
}
