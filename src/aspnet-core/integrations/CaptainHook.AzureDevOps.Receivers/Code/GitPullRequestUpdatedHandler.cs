using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestUpdatedHandler : AzureDevOpsHandler<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
        {
        }
    }
}
