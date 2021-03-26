using CaptainHook.AzureDevOps.Payload;
using CaptainHook.WebHooks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Receiver
{
    /// <inheritdoc/>
    class AzureDevOpsReceiver : IWebhookReceiver, ITransientDependency
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected AzureDevOpsOptions Options { get; }

        public AzureDevOpsReceiver(IServiceScopeFactory serviceScopeFactory, IOptions<AzureDevOpsOptions> options)
        {
            ServiceScopeFactory = serviceScopeFactory;
            Options = options.Value;
        }

        /// <inheritdoc/>
        public async Task<object> ReceiveAsync(IWebHookExecutionContext context)
        {
            EventPayload meta = JsonConvert.DeserializeObject<EventPayload>(context.Payload.ToString());

            var handlerType = Options.Handlers[meta.EventType];

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var receiver = (IAzureDevOpsHandler)scope.ServiceProvider.GetRequiredService(handlerType);

                return await receiver.HandleAsync(context);
            }
        }
    }
}
