using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps.Pipelines
{
    public class PipelineRunStateChangedPublisher : AzureDevOpsPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedPublisher(ILocalEventBus eventBus)
            : base(eventBus)
        {
        }
    }
}
