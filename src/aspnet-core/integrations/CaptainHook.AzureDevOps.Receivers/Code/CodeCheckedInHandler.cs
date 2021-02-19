using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class CodeCheckedInHandler : AzureDevOpsHandler<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
