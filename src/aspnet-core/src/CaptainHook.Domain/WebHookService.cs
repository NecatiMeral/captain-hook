using CaptainHook.Receivers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace CaptainHook
{
    public class WebHookService : DomainService, IWebHookService
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected IReceiverSelector ReceiverSelector { get; }

        public WebHookService(IServiceScopeFactory serviceScopeFactory, IReceiverSelector receiverSelector)
        {
            ServiceScopeFactory = serviceScopeFactory;
            ReceiverSelector = receiverSelector;
        }

        public async Task ProcessAsync(string name, string id, dynamic content)
        {
            var context = new DefaultWebHookExecutionContext(
                name, id, content
            );

            var receiverType = ReceiverSelector.Select(context);

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var receiver = (IWebhookReceiver)scope.ServiceProvider.GetRequiredService(receiverType);

                try
                {
                    await receiver.ReceiveAsync(context);
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
