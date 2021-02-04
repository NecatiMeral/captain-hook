using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestMergedPublisher : AzureDevOpsPublisher<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestMerged)
        {
        }
    }
}
