using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.Receivers.AzureDevOps;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
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

            ConfigurePublisherRegistry();
            ConfigureObjectMapper(context);
        }

        private void ConfigurePublisherRegistry()
        {
            Configure<CaptainHookPublisherRegistryOptions>(o =>
            {
                o.PublisherHandlers.GetOrAdd(AzureDevOpsConstants.ReceiverName, AzureDevOpsRocketChatConsts.PublisherName)
                    .Append<GitPullRequestUpdatedHandler>(AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
                    .Append<PipelineRunStateChangedHandler>(AzureDevOpsConstants.EventType.Pipelines.RunStateChanged);
            });
        }

        public void ConfigureObjectMapper(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<CaptainHookPublishersAzureDevOpsRocketChatModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AzureDevOpsRocketChatAutoMapperProfile>(validate: true);
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            var authenticator = context.ServiceProvider.GetRequiredService<IRocketChatAuthenticator>();
            authenticator.SignOffAsync().GetAwaiter().GetResult();
        }
    }
}
