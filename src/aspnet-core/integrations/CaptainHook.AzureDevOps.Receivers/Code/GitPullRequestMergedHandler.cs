using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestMergedHandler : AzureDevOpsHandler<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedHandler(ICaptainHookEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestMerged)
        {
        }
    }
}
