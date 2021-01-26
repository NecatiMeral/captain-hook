using Newtonsoft.Json;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Receivers.AzureDevOps
{
    public abstract class AzureDevOpsPublisher<TPayload> : IAzureDevOpsHandler
    {
        protected ILocalEventBus EventBus { get; }

        public AzureDevOpsPublisher(ILocalEventBus eventBus)
        {
            EventBus = eventBus;
        }

        public async Task<object> HandleAsync(IWebHookExecutionContext context)
        {
            var payload = Parse(context.Content);
            var @event = new WebHookHandledEvent<TPayload>()
            {
                Id = context.Id,
                Name = AzureDevOpsConstants.ReceiverName,
                Payload = payload
            };

            await EventBus.PublishAsync(@event);

            return payload;
        }

        protected TPayload Parse(dynamic value)
        {
            return JsonConvert.DeserializeObject<TPayload>(value.ToString());
        }
    }
}
