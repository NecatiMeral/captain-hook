using CaptainHook.EventBus;
using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    public interface ICaptainHookPublisherManager
    {
        Task HandleEventAsync(HookEvent eventData);
    }
}