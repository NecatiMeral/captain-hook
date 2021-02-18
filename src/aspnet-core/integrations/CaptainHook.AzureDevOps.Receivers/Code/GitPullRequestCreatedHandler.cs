using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestCreatedHandler : AzureDevOpsHandler<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedHandler(ICaptainHookEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
