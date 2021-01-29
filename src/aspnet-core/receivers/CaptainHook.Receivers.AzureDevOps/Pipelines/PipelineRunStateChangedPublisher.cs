using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Pipelines
{
    public class PipelineRunStateChangedPublisher : AzureDevOpsPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
