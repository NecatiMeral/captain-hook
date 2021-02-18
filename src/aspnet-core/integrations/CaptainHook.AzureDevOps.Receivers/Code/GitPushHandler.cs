using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class GitPushHandler : AzureDevOpsHandler<GitPushPayload>, ITransientDependency
    {
        public GitPushHandler(ICaptainHookEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.CodePushed)
        {
        }
    }
}
