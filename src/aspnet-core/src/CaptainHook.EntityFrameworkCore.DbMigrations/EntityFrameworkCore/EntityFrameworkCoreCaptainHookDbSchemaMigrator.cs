using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CaptainHook.Data;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.EntityFrameworkCore
{
    public class EntityFrameworkCoreCaptainHookDbSchemaMigrator
        : ICaptainHookDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreCaptainHookDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the CaptainHookMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<CaptainHookMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}