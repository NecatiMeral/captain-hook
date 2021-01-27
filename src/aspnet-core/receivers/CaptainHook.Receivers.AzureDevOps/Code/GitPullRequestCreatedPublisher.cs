using CaptainHook.Receivers.AzureDevOps.Payload;
using CaptainHook.Receivers.Queue;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestCreatedPublisher : LocalAzureDevOpsPublisher<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
