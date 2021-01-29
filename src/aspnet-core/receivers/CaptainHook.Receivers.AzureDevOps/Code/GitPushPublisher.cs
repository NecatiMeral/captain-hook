using CaptainHook.Queue;
using CaptainHook.Receivers.AzureDevOps.Payload;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps.Code
{
    public class GitPushPublisher : AzureDevOpsPublisher<GitPushPayload>, ITransientDependency
    {
        public GitPushPublisher(IEventQueue queue)
            : base(queue, AzureDevOpsConstants.EventType.Code.CodePushed)
        {
        }
    }
}
