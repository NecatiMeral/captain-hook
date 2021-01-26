﻿using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.Receivers.AzureDevOps;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    [DependsOn(
        typeof(CaptainHookAzureDevOpsReceiverModule),
        typeof(AbpHttpClientModule)
    )]
    public class CaptainHookPublishersAzureDevOpsRocketChatModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            var authenticator = context.ServiceProvider.GetRequiredService<IRocketChatAuthenticator>();
            authenticator.SignOffAsync().GetAwaiter().GetResult();
        }
    }
}