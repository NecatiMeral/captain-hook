using System.Threading.Tasks;

namespace CaptainHook.Receivers
{
    public interface IWebhookReceiver
    {
        Task<object> ReceiveAsync(IWebHookExecutionContext context);
    }
}
