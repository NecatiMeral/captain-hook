using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestMergedHandler : AzureDevOpsHandler<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestMerged)
        {
        }
    }
}
