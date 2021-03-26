using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace CaptainHook.AzureDevOps
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpEventBusModule)
        )]
    public class CaptainHookAzureDevOpsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureObjectMapper(context);
        }

        public void ConfigureObjectMapper(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<CaptainHookAzureDevOpsModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CaptainHookAzureDevOpsModule>(validate: true);
            });
        }
    }
}
