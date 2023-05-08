using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using test;

namespace ListaDePessoas
{
    internal static class Program
    {
        private static string conectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;

        [STAThread]
        static void Main(string[] args)
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaDeFuncionarios());

        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(conectionString)
            .ScanIn(typeof(AddFuncionarioTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }        
    }
}
