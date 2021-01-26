using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPushPublisher : AzureDevOpsPublisher<GitPushPayload>, ITransientDependency
    {
        public GitPushPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
