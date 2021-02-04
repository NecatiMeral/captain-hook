using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestUpdatedPublisher : AzureDevOpsPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
        {
        }
    }
}
