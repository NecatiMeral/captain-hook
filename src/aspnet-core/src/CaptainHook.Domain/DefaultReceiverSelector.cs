using CaptainHook.Receivers;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.DependencyInjection;

namespace CaptainHook
{
    public class DefaultReceiverSelector : IReceiverSelector, ITransientDependency
    {
        public WebHookOptions Options { get; }

        public DefaultReceiverSelector(IOptions<WebHookOptions> options)
        {
            Options = options.Value;
        }

        public Type Select(IWebHookExecutionContext context)
        {
            if (!Options.Handlers.ContainsKey(context.Name))
            {
                throw new NotImplementedException(context.Name);
            }

            return Options.Handlers[context.Name];
        }
    }
}
