using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class CodeCheckedInPublisher : AzureDevOpsPublisher<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
