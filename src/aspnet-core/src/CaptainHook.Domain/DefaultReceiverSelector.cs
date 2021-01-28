using CaptainHook.Receivers;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.DependencyInjection;

namespace CaptainHook
{
    public class DefaultReceiverSelector : IReceiverSelector, ITransientDependency
    {
        public CaptainHookProcessingOptions Options { get; }

        public DefaultReceiverSelector(IOptions<CaptainHookProcessingOptions> options)
        {
            Options = options.Value;
        }

        /// <inheritdoc/>
        public ReceiverResolution Select(IWebHookExecutionContext context)
        {
            if (!Options.Handlers.ContainsKey(context.HandlerName))
            {
                throw new NotImplementedException(context.HandlerName);
            }

            var matchingReceiver = Options.Receive.Find(x =>
                string.Equals(x.HandlerName, context.HandlerName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Identifier, context.Identifier, StringComparison.OrdinalIgnoreCase));

            if (matchingReceiver == null)
            {
                return null;
            }

            return new ReceiverResolution(
                Options.Handlers[context.HandlerName],
                matchingReceiver
            );
        }
    }
}
