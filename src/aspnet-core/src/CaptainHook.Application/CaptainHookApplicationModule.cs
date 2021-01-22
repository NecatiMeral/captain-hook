using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookDomainModule),
        typeof(AbpAutoMapperModule),
        typeof(CaptainHookApplicationContractsModule)
        )]
    public class CaptainHookApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CaptainHookApplicationModule>();
            });
        }
    }
}
