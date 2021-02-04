using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPushPublisher : AzureDevOpsPublisher<GitPushPayload>, ITransientDependency
    {
        public GitPushPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodePushed)
        {
        }
    }
}
