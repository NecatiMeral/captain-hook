using CaptainHook.Receivers.AzureDevOps.Payload;
using CaptainHook.Receivers.Queue;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Pipelines
{
    public class PipelineRunStateChangedPublisher : LocalAzureDevOpsPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
