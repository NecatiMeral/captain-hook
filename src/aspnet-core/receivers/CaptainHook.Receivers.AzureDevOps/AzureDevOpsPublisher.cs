using CaptainHook.Queue;
using CaptainHook.WebHooks;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CaptainHook.Receivers.AzureDevOps
{
    public abstract class AzureDevOpsPublisher<TPayload> : IAzureDevOpsHandler
    {
        protected IEventQueue EventBus { get; }
        protected string EventType { get; }

        public AzureDevOpsPublisher(IEventQueue queue, string eventType)
        {
            EventBus = queue;
            EventType = eventType;
        }

        public async Task<object> HandleAsync(IWebHookExecutionContext context)
        {
            var payload = (TPayload)Parse(context.Payload);

            await EventBus.PublishAsync(AzureDevOpsConstants.ReceiverName, context.Identifier, EventType, payload);

            return null;
        }

        protected TPayload Parse(dynamic value)
        {
            return JsonConvert.DeserializeObject<TPayload>(value.ToString());
        }
    }
}
