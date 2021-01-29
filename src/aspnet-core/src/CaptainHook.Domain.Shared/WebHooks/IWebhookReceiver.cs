using System.Threading.Tasks;

namespace CaptainHook.WebHooks
{
    /// <summary>
    /// Processed incoming webhooks
    /// </summary>
    public interface IWebhookReceiver
    {
        /// <summary>
        /// Process a incoming webhook.
        /// </summary>
        /// <param name="context">Contextual information about the current invocation.</param>
        /// <returns>Returns something which should be returned as a response.</returns>
        Task<object> ReceiveAsync(IWebHookExecutionContext context);
    }
}
