using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestMergedPublisher : AzureDevOpsPublisher<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestMerged)
        {
        }
    }
}
