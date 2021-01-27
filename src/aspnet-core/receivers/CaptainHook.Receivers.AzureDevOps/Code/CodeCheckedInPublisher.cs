using CaptainHook.Receivers.AzureDevOps.Payload;
using CaptainHook.Receivers.Queue;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class CodeCheckedInPublisher : LocalAzureDevOpsPublisher<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
