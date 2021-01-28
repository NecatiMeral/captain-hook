using System.Threading.Tasks;

namespace CaptainHook
{
    public interface IIncomingWebHookAppService
    {
        Task<object> ReceiveAsync(string name, string id, dynamic content);
    }
}