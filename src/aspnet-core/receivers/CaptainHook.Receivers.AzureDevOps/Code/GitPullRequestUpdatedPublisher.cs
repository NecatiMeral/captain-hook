using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestUpdatedPublisher : AzureDevOpsPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
        {
        }
    }
}
