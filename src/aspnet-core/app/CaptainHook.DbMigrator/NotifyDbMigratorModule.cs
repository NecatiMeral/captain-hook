using CaptainHook.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CaptainHook.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CaptainHookEntityFrameworkCoreDbMigrationsModule),
        typeof(CaptainHookApplicationContractsModule)
        )]
    public class CaptainHookDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
