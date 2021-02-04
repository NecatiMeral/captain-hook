using CaptainHook.EventBus;
using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    public interface IEventPublisher<T> : IEventPublisher
    {
        Task HandleEventAsync(HookEventToPublish<T> eventData);
    }

    public interface IEventPublisher
    {

    }
}
