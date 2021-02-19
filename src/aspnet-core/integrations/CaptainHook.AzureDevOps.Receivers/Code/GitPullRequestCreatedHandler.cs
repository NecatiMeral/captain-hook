using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestCreatedHandler : AzureDevOpsHandler<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
