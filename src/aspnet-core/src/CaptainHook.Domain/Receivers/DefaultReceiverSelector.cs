using CaptainHook.Receivers;
using CaptainHook.WebHooks;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers
{
    public class DefaultReceiverSelector : IReceiverSelector, ITransientDependency
    {
        public CaptainHookReceiverHandlerOptions Handlers { get; }
        public CaptainHookReceiverOptions Receivers { get; }

        public DefaultReceiverSelector(IOptions<CaptainHookReceiverHandlerOptions> handlerOptions,
            IOptions<CaptainHookReceiverOptions> receiverOptions)
        {
            Handlers = handlerOptions.Value;
            Receivers = receiverOptions.Value;
        }

        /// <inheritdoc/>
        public ReceiverResolution Select(IWebHookExecutionContext context)
        {
            if (!Handlers.Handlers.ContainsKey(context.HandlerName))
            {
                throw new NotImplementedException(context.HandlerName);
            }

            var matchingReceiver = Receivers.Receive.Find(x =>
                string.Equals(x.HandlerName, context.HandlerName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Identifier, context.Identifier, StringComparison.OrdinalIgnoreCase));

            if (matchingReceiver == null)
            {
                return null;
            }

            return new ReceiverResolution(
                Handlers.Handlers[context.HandlerName],
                matchingReceiver
            );
        }
    }
}
