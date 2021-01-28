using CaptainHook.Receivers;
using System.Threading.Tasks;

namespace CaptainHook
{
    /// <summary>
    /// Resolves and processes raw incoming webhook data.
    /// </summary>
    public interface IWebHookService
    {
        /// <summary>
        /// Processes a incoming webhook.
        /// </summary>
        /// <param name="handlerName">Indicates the handler's type (name) to use.</param>
        /// <param name="identifier">Unique ID of the handler instance.</param>
        /// <param name="payload">json payload</param>
        /// <returns>Returns a payload which should returned to the caller.</returns>
        Task<object> ProcessAsync(string handlerName, string identifier, dynamic payload);
    }
}