using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestCreatedPublisher : AzureDevOpsPublisher<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.PullRequestCreated)
        {
        }
    }
}
