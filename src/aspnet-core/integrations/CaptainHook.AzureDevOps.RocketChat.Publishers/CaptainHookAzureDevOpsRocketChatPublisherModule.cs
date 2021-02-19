using CaptainHook.AzureDevOps.Client;
using CaptainHook.AzureDevOps.Client.Authentication;
using CaptainHook.AzureDevOps.RocketChat.Publisher.Code;
using CaptainHook.Publishers;
using CaptainHook.RocketChat;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace CaptainHook.AzureDevOps.RocketChat.Publisher
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAutoMapperModule),
        typeof(CaptainHookAzureDevOpsModule),
        typeof(CaptainHookRocketChatModule)
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
                    .AppendScopedDependency<IRocketChatClientOptionsProvider>()
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
    }
}
