using CaptainHook.AzureDevOps.Receiver.Code;
using CaptainHook.AzureDevOps.Receiver.Pipelines;
using CaptainHook.Receivers;
using Volo.Abp.AutoMapper;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace CaptainHook.AzureDevOps.Receiver
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpEventBusModule),
        typeof(CaptainHookAzureDevOpsModule)
        )]
    public class CaptainHookAzureDevOpsReceiverModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<CaptainHookReceiverHandlerOptions>(options =>
            {
                options.Handlers[AzureDevOpsConstants.ReceiverName] = typeof(AzureDevOpsReceiver);
            });

            Configure<AzureDevOpsOptions>(options =>
            {
                options.Handlers[AzureDevOpsConstants.EventType.Code.CodeCheckedIn] = typeof(CodeCheckedInHandler);
                options.Handlers[AzureDevOpsConstants.EventType.Code.CodePushed] = typeof(GitPushHandler);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestCreated] = typeof(GitPullRequestCreatedHandler);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestUpdated] = typeof(GitPullRequestUpdatedHandler);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestMerged] = typeof(GitPullRequestMergedHandler);
                options.Handlers[AzureDevOpsConstants.EventType.Code.PullRequestCommented] = typeof(GitPullRequestCommentedHandler);

                options.Handlers[AzureDevOpsConstants.EventType.Pipelines.RunStateChanged] = typeof(PipelineRunStateChangedHandler);
            });
        }
    }
}
