using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Data
{
    public class CaptainHookDbMigrationService : ITransientDependency
    {
        public ILogger<CaptainHookDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<ICaptainHookDbSchemaMigrator> _dbSchemaMigrators;

        public CaptainHookDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<ICaptainHookDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;

            Logger = NullLogger<CaptainHookDbMigrationService>.Instance;
        }

        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");

            await MigrateDatabaseSchemaAsync();
            await SeedDataAsync();

            Logger.LogInformation("Successfully completed database migrations.");
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation($"Migrating schema for host database...");

            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }

        private async Task SeedDataAsync()
        {
            Logger.LogInformation($"Executing host database seed...");

            await _dataSeeder.SeedAsync();
        }
    }
}
