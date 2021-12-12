using PrototipoERP.Infraestrutura.Database.Daos;

namespace PrototipoERP.Infraestrutura.IoC
{
    public static class InjecaoDependencias
    {
        public static void ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IEntityDao, UsuarioDao>();
            services.AddScoped<ILembreteDao, LembreteDao>();
        }
    }
}
