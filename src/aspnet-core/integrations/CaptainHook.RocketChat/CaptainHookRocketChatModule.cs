using CaptainHook.RocketChat;
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
            var authenticator = context.ServiceProvider.GetRequiredService<IRocketChatAuthenticator>();
            authenticator.SignOffAsync().GetAwaiter().GetResult();
        }
    }
}
