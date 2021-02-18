using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Code
{
    public class CodeCheckedInHandler : AzureDevOpsHandler<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInHandler(ICaptainHookEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
