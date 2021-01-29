using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Caching;
using CaptainHook.Receivers;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookDomainSharedModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule)
    )]
    public class CaptainHookDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
