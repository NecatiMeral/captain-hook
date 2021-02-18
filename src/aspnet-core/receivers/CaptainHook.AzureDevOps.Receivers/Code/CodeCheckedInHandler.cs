using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Code
{
    public class CodeCheckedInHandler : AzureDevOpsHandler<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
