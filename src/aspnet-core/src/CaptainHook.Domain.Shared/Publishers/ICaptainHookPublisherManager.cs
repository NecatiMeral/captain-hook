using CaptainHook.EventBus;
using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    /// <summary>
    /// Receives and delegates events to the configured publishers.
    /// </summary>
    public interface ICaptainHookPublisherManager
    {
        Task HandleEventAsync(HookEvent eventData);
    }
}