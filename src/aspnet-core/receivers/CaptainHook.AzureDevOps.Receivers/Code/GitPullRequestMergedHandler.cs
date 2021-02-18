using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Code
{
    public class GitPullRequestMergedHandler : AzureDevOpsHandler<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestMerged)
        {
        }
    }
}
