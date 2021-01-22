using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace CaptainHook.EntityFrameworkCore
{
    [DependsOn(
        typeof(CaptainHookEntityFrameworkCoreModule)
        )]
    public class CaptainHookEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CaptainHookMigrationsDbContext>();
        }
    }
}
