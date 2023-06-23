using FluentMigrator.Exceptions;
using FluentMigrator.Postgres;
using FluentMigrator.Runner;
using Microsoft.OpenApi.Writers;
using MigrationsPlayGround.Mirgations;

namespace MigrationsPlayGround.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    //databaseService.CreateDatabase("MigrationExample");

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();

                    //migrationService.MigrateDown(202106280001);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }

            return host;
        }
    }
}
