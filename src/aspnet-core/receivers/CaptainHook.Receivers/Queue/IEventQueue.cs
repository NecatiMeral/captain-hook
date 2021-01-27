using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaptainHook.Receivers.Queue
{
    public interface IEventQueue
    {
        Task PublishAsync<T>(string receiverName, string id, string eventType, T payload);
        Task<IDisposable> SubscribeAsync<T>(string receiverName, string id, string eventType, Func<T, Task> handler);
    }
}
