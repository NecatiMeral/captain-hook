using CaptainHook.WebHooks;

namespace CaptainHook.Receivers
{
    public interface IReceiverSelector
    {
        /// <summary>
        /// Resolves the execution context to a matching handler.
        /// </summary>
        /// <returns>Retuns handler information or null.</returns>
        ReceiverResolution Select(IWebHookExecutionContext context);
    }
}
