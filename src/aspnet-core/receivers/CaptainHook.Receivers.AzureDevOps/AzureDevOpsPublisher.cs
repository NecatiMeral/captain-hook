using CaptainHook.EventBus;
using CaptainHook.WebHooks;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers.AzureDevOps
{
    public abstract class AzureDevOpsPublisher<TPayload> : IAzureDevOpsHandler
    {
        protected IDistributedEventBus EventBus { get; }
        protected string EventType { get; }

        public AzureDevOpsPublisher(IDistributedEventBus queue, string eventType)
        {
            EventBus = queue;
            EventType = eventType;
        }

        public async Task<object> HandleAsync(IWebHookExecutionContext context)
        {
            var payload = (TPayload)Parse(context.Payload);

            await EventBus.PublishAsync(typeof(HookEvent), new HookEvent
            {
                Id = context.Identifier,
                EventType = EventType,
                ReceiverName = AzureDevOpsConstants.ReceiverName,
                Payload = payload
            });

            return null;
        }

        protected TPayload Parse(dynamic value)
        {
            return JsonConvert.DeserializeObject<TPayload>(value.ToString());
        }
    }
}
