using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Code
{
    public class GitPullRequestUpdatedHandler : AzureDevOpsHandler<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
        {
        }
    }
}
