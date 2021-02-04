using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class CodeCheckedInPublisher : AzureDevOpsPublisher<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodeCheckedIn)
        {
        }
    }
}
