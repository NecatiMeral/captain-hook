using CaptainHook.AzureDevOps.Payload;
using CaptainHook.EventBus;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver.Pipelines
{
    public class PipelineRunStateChangedHandler : AzureDevOpsHandler<PipelineRunStateChangedPayload>, ITransientDependency
    {
        public PipelineRunStateChangedHandler(ICaptainHookEventBus queue)
            : base(queue, AzureDevOpsConstants.EventType.Pipelines.RunStateChanged)
        {
        }
    }
}
