using CaptainHook.RocketChat.Client;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace CaptainHook.AzureDevOps
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpEventBusModule)
        )]
    public class CaptainHookRocketChatModule : AbpModule
    {
        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            var authenticationStore = context.ServiceProvider.GetRequiredService<IRocketChatAuthenticationStore>();
            authenticationStore.SignOffAsync().GetAwaiter().GetResult();
        }
    }
}
