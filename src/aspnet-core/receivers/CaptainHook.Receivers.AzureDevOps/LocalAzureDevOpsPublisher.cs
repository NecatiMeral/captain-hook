using CaptainHook.Receivers.Queue;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CaptainHook.Receivers.AzureDevOps
{
    public abstract class LocalAzureDevOpsPublisher<TPayload> : IAzureDevOpsHandler
    {
        protected IEventQueue EventBus { get; }
        protected string EventType { get; }

        public LocalAzureDevOpsPublisher(IEventQueue queue, string eventType)
        {
            EventBus = queue;
            EventType = eventType;
        }

        public async Task<object> HandleAsync(IWebHookExecutionContext context)
        {
            var payload = Parse(context.Content);

            await EventBus.PublishAsync(AzureDevOpsConstants.ReceiverName, context.Id, EventType, payload);

            return payload;
        }

        protected TPayload Parse(dynamic value)
        {
            return JsonConvert.DeserializeObject<TPayload>(value.ToString());
        }
    }
}
