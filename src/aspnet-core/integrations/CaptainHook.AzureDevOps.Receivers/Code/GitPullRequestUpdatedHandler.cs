using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestUpdatedHandler : AzureDevOpsHandler<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedHandler(ICaptainHookEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestUpdated)
        {
        }
    }
}
