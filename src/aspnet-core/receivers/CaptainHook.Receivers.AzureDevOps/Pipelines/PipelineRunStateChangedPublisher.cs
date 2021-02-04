using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps.Pipelines
{
    public class PipelineRunStateChangedPublisher : AzureDevOpsPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedPublisher(IDistributedEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
