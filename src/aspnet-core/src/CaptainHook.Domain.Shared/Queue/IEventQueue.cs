using System;
using System.Threading.Tasks;

namespace CaptainHook.Queue
{
    public interface IEventQueue
    {
        Task PublishAsync<T>(string receiverName, string id, string eventType, T payload);
        Task<IDisposable> SubscribeAsync<T>(string receiverName, string id, string eventType, Func<T, Task> handler);
    }
}
