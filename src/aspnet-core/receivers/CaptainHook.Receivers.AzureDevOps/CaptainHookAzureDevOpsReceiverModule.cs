using CaptainHook.Receivers.AzureDevOps.Code;
using CaptainHook.Receivers.AzureDevOps.Pipelines;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace CaptainHook.Receivers.AzureDevOps
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(CaptainHookReceiverModule)
        )]
    public class CaptainHookAzureDevOpsReceiverModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<WebHookOptions>(options =>
            {
                options.Handlers[AzureDevOpsConstants.ReceiverName] = typeof(AzureDevOpsReceiver);
            });

            Configure<AzureDevOpsOptions>(options =>
            {
                options.Handlers[AzureDevOpsConstants.EventType.Code.CodeCheckedIn] = typeof(CodeCheckedInPublisher);
                options.Handlers[AzureDevOpsConstants.EventType.Code.CodePushed] = typeof(GitPushPublisher);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestCreated] = typeof(GitPullRequestCreatedPublisher);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestUpdated] = typeof(GitPullRequestUpdatedPublisher);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestMerged] = typeof(GitPullRequestMergedPublisher);

                options.Handlers[AzureDevOpsConstants.EventType.Pipelines.RunStateChanged] = typeof(PipelineRunStateChangedPublisher);
            });
        }
    }
}
