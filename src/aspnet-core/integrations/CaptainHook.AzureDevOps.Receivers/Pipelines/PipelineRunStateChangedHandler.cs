using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receiver.Pipelines
{
    public class PipelineRunStateChangedHandler : AzureDevOpsHandler<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedHandler(IDistributedEventBus bus)
            : base(bus, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
