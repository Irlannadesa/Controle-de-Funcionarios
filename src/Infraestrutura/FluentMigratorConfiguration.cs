using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using test;

namespace Infraestrutura
{
    public class ConfiguracaoFluentMigrator
    {
        private readonly string connectionString;

        public ConfiguracaoFluentMigrator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ConfigureMigrations()
        {
            var serviceProvider = CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AddFuncionarioTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }

  
}
