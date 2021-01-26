using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPullRequestMergedPublisher : AzureDevOpsPublisher<GitPullRequestMergeCommitCreatedPayload>, ITransientDependency
    {
        public GitPullRequestMergedPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
