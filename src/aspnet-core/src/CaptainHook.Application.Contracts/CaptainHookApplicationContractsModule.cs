using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookDomainSharedModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class CaptainHookApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            CaptainHookDtoExtensions.Configure();
        }
    }
}
