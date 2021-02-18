using CaptainHook.AzureDevOps.Client;
using CaptainHook.AzureDevOps.Client.Authentication;
using CaptainHook.AzureDevOps.RocketChat.Publishers.Client;
using CaptainHook.AzureDevOps.RocketChat.Publishers.Code;
using CaptainHook.Publishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers
{
    [DependsOn(
        typeof(CaptainHookAzureDevOpsModule),
        typeof(AbpHttpClientModule),
        typeof(AbpAutoMapperModule)
    )]
    public class CaptainHookAzureDevOpsRocketChatPublishersModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
            var configuration = context.Services.GetConfiguration();

            ConfigureAzureDevOps(configuration);
            ConfigurePublisherRegistry();
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

        public void ConfigureAzureDevOps(IConfiguration configuration)
        {
            // Make the options configurable per publisher instance
            Configure<AzureDevOpsOptions>(configuration.GetSection("AzureDevOps"));

            Configure<AzureDevOpsAuthenticationOptions>(configuration.GetSection("AzureDevOps:Authentication"));
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            var authenticator = context.ServiceProvider.GetRequiredService<IRocketChatAuthenticator>();
            authenticator.SignOffAsync().GetAwaiter().GetResult();
        }
    }
}
