﻿using Microsoft.EntityFrameworkCore;

namespace PrototipoERP.Configuracoes.Database
{
    public static class MigrationsDb
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
