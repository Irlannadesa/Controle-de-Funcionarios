using Dominio;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura
{
    public class InjecaoDeDependencia
    {
        public static IServiceProvider ConfigureDependencies()
        {
            var services = new ServiceCollection();
            services.AddScoped<IFuncionarios, RepositorioBancoDeDadosSqlFuncionarios>();
            return services.BuildServiceProvider();
        }
    }

}
