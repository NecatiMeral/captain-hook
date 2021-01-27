using System.Threading.Tasks;
using Volo.Abp.EventBus;

namespace CaptainHook.Receivers.Queue
{
    public interface IEventQueueHandler<in TEvent> : IEventHandler
    {
        Task HandleEventAsync(TEvent eventData);
    }
}
