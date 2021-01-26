using CaptainHook.Receivers;
using System.Threading.Tasks;

namespace CaptainHook
{
    public interface IWebHookService
    {
        Task ProcessAsync(string name, string id, dynamic content);
    }
}