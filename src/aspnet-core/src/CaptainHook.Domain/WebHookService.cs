using CaptainHook.Receivers;
using CaptainHook.WebHooks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace CaptainHook
{
    /// <inheritdoc cref="IWebHookService"/>
    public class WebHookService : DomainService, IWebHookService
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected IReceiverSelector ReceiverSelector { get; }
        protected IConfiguration Configuration { get; }

        public WebHookService(IServiceScopeFactory serviceScopeFactory, IReceiverSelector receiverSelector, IConfiguration configuration)
        {
            ServiceScopeFactory = serviceScopeFactory;
            ReceiverSelector = receiverSelector;
            Configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<object> ProcessAsync(string handlerName, string identifier, dynamic payload)
        {
            // AzureDevOps, 1, <json>
            var context = new DefaultWebHookExecutionContext(
                handlerName, identifier, payload
            );

            var match = ReceiverSelector.Select(context);
            if (match == null)
            {
                throw new Exception("Invalid handler-name or identifier.");
            }

            var configuration = GetHandlerConfigurationInputs(handlerName, identifier);
            context.EnrichConfiguration(configuration);

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var implementation = (IWebhookReceiver)scope.ServiceProvider.GetRequiredService(match.Handler);
                var response = await implementation.ReceiveAsync(context);

                return response;
            }
        }

        /// <summary>
        /// Tries to find a configuration section for the handler.
        /// This should be located at `CaptainHook:Receive:[INDEX]:Inputs` to get matched automagically.
        /// </summary>
        /// <param name="handlerName"></param>
        /// <param name="identifier"></param>
        /// <returns>Retuns a configuration (if found) or null otherwise.</returns>
        IConfiguration GetHandlerConfigurationInputs(string handlerName, string identifier)
        {
            var allHandlerSections = Configuration
                .GetSection("CaptainHook:Receive")
                .GetChildren();

            foreach (var section in allHandlerSections)
            {
                var parse = section.Get<CaptainHookReceiverItem>();
                if (parse.Equals(handlerName, identifier))
                {
                    return section.GetSection("Inputs");
                }
            }

            return null;
        }

    }
}
