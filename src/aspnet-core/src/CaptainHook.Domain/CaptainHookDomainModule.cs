using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp;
using Volo.Abp.EventBus;
using CaptainHook.Publishers;
using Microsoft.Extensions.DependencyInjection;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookDomainSharedModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule),
        typeof(AbpEventBusModule)
    )]
    public class CaptainHookDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<CaptainHookPublisherOptions>(configuration.GetSection("CaptainHook"));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context
                .ServiceProvider
                .GetRequiredService<CaptainHookPublisherManager>()
                .Initialize();
        }
    }
}
