using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Code
{
    public class GitPushHandler : AzureDevOpsHandler<GitPushPayload>, ITransientDependency
    {
        public GitPushHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodePushed)
        {
        }
    }
}
