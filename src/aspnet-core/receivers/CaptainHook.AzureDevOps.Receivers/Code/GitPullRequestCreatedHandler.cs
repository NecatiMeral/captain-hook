using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Code
{
    public class GitPullRequestCreatedHandler : AzureDevOpsHandler<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
