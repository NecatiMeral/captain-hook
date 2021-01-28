using CaptainHook.Receivers;
using Microsoft.Extensions.Configuration;

namespace CaptainHook
{
    /// <inheritdoc/>
    class DefaultWebHookExecutionContext : IWebHookExecutionContext
    {
        /// <inheritdoc/>
        public string HandlerName { get; }

        /// <inheritdoc/>
        public string Identifier { get; }

        /// <inheritdoc/>
        public dynamic Payload { get; }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; private set; }

        public DefaultWebHookExecutionContext(string name, string id, dynamic content)
        {
            HandlerName = name;
            Identifier = id;
            Payload = content;
        }

        /// <summary>
        /// Appends configuration information which can be used by the receiver.
        /// </summary>
        public void EnrichConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
