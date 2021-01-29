using Microsoft.Extensions.Configuration;

namespace CaptainHook.WebHooks
{
    /// <summary>
    /// Encapsulates required information to process a incoming webhook.
    /// </summary>
    public interface IWebHookExecutionContext
    {
        /// <summary>
        /// The handler name which should be invoked.
        /// </summary>
        string HandlerName { get; }

        /// <summary>
        /// A unique identifier to distingush between multiple instances of the same handler-type
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// The incoming payload.
        /// </summary>
        dynamic Payload { get; }

        /// <summary>
        /// (Optional) A separated configuration which can contain additional options for the handler implementation.
        /// </summary>
        IConfiguration Configuration { get; }
    }
}
