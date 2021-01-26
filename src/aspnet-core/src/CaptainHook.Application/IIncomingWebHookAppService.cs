using System.Threading.Tasks;

namespace CaptainHook
{
    public interface IIncomingWebHookAppService
    {
        Task ReceiveAsync(string name, string id, dynamic content);
    }
}