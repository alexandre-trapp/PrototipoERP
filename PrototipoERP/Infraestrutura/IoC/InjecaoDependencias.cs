using PrototipoERP.Entidades;
using PrototipoERP.Infraestrutura.Database.Daos;

namespace PrototipoERP.Infraestrutura.IoC
{
    public static class InjecaoDependencias
    {
        public static void ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioDao<Usuario>, UsuarioDao>();
            services.AddScoped<ILembreteDao<Lembrete>, LembreteDao>();
        }
    }
}
