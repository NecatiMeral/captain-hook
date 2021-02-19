using Volo.Abp.EventBus;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace CaptainHook
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpEventBusModule),
        typeof(CaptainHookDomainSharedModule)
        )]
    public class CaptainHookPublisherModule : AbpModule
    {
    }
}
