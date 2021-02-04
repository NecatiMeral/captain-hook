using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestCreatedPublisher : AzureDevOpsPublisher<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
