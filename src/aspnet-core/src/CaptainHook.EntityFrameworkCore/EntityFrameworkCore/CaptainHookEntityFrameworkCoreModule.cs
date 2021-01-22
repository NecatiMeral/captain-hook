using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace CaptainHook.EntityFrameworkCore
{
    [DependsOn(
        typeof(CaptainHookDomainModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
        )]
    public class CaptainHookEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CaptainHookDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also CaptainHookMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlite();
            });
        }
    }
}
