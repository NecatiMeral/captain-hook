using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps
{
    public class CodeCheckedInPublisher : AzureDevOpsPublisher<CodeCheckedInPayload>, ITransientDependency
    {
        public CodeCheckedInPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
