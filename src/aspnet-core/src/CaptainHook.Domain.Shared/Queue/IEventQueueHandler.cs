using System.Threading.Tasks;

namespace CaptainHook.Queue
{
    public interface IEventQueueHandler<in TEvent> : IEventQueueHandler
    {
        Task HandleEventAsync(TEvent eventData);
    }

    public interface IEventQueueHandler
    {
    }
}
