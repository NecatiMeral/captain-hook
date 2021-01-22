using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Caching;

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
