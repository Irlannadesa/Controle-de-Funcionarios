using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ListaDePessoas
{
    internal static class Program
    {


        static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;

            var migratorConfiguration = new ConfiguracaoFluentMigrator(connectionString);
            migratorConfiguration.ConfigureMigrations();

            var serviceProvider = InjecaoDeDependencia.ConfigureDependencies();
            var repositorio = serviceProvider.GetService<IFuncionarios>();

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaDeFuncionarios(repositorio));
        }

    }
}
