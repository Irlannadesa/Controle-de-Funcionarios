using Infraestrutura.InjecaoDependencia;
using Infraestrutura.MigracaoBD;
using Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ControleDeFuncionarios
{
    internal static class Program
    {
        static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;

            var migratorConfiguration = new ConfiguracaoFluentMigrator(connectionString);
            migratorConfiguration.ConfigureMigrations();

            var serviceProvider = InjecaoDeDependencia.ConfigureDependencies();
            var repositorioFuncionarios = serviceProvider.GetService<IFuncionarios>();

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaDeFuncionarios(repositorioFuncionarios));
        }
    }
}
     
