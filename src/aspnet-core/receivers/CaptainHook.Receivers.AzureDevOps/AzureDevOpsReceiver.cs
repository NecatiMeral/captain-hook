using CaptainHook.Receivers.AzureDevOps.Payload;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.AzureDevOps
{
    class AzureDevOpsReceiver : IWebhookReceiver, ITransientDependency
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected AzureDevOpsOptions Options { get; }

        public AzureDevOpsReceiver(IServiceScopeFactory serviceScopeFactory, IOptions<AzureDevOpsOptions> options)
        {
            ServiceScopeFactory = serviceScopeFactory;
            Options = options.Value;
        }

        public async Task<object> ReceiveAsync(IWebHookExecutionContext context)
        {
            EventPayload meta = JsonConvert.DeserializeObject<EventPayload>(context.Content.ToString());

            var handlerType = Options.Handlers[meta.EventType];

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var receiver = (IAzureDevOpsHandler)scope.ServiceProvider.GetRequiredService(handlerType);

                try
                {
                    return await receiver.HandleAsync(context);
                }
                catch (Exception)
                {
                    // TODO LOG
                    throw;
                }
            }
        }
    }
}
