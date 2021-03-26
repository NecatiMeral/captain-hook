using CaptainHook.EventBus;
using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    public interface ICaptainHookPublisherProcessor
    {
        Task HandleEventAsync(HookEvent eventData);
    }
}