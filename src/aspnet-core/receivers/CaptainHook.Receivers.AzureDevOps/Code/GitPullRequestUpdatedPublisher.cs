using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestUpdatedPublisher : AzureDevOpsPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        public GitPullRequestUpdatedPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
