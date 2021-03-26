using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPushHandler : AzureDevOpsHandler<GitPushPayload>, ITransientDependency
    {
        public GitPushHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.CodePushed)
        {
        }
    }
}
