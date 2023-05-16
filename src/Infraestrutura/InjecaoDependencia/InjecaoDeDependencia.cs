using Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura.InjecaoDependencia
{
    public class InjecaoDeDependencia
    {
        public static IServiceProvider ConfigureDependencies()
        {
            var services = new ServiceCollection();
            services.AddScoped<IFuncionarios, RepositorioLinkTwoDB>();
            return services.BuildServiceProvider();
        }
    }

}
