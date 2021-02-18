using CaptainHook.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.AzureDevOps.Receivers.Pipelines
{
    public class PipelineRunStateChangedHandler : AzureDevOpsHandler<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedHandler(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
