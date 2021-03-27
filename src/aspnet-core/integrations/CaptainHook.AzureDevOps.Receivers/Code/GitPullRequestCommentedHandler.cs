using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPullRequestCommentedHandler : AzureDevOpsHandler<GitPullRequestCommentedPayload>, ITransientDependency
    {
        public GitPullRequestCommentedHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.PullRequestCommented)
        {
        }
    }
}
