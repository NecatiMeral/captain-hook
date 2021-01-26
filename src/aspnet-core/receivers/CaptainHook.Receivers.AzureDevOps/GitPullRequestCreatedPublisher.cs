using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps
{
    public class GitPullRequestCreatedPublisher : AzureDevOpsPublisher<GitPullRequestCreatedPayload>, ITransientDependency
    {
        public GitPullRequestCreatedPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
