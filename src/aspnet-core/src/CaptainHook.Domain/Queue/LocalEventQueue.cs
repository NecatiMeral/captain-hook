using System;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.Queue
{
    public class LocalEventQueue : IEventQueue
    {
        protected ILocalEventBus LocalEventBus { get; }

        public LocalEventQueue(ILocalEventBus localEventBus)
        {
            LocalEventBus = localEventBus;
        }

        public async Task PublishAsync<T>(string receiverName, string id, string eventType, T payload)
        {
            var item = new LocalEventQueueItem<T>
            {
                ReceiverName = receiverName,
                Id = id,
                EventType = eventType,
                Payload = payload
            };

            await LocalEventBus.PublishAsync(item);
        }

        public Task<IDisposable> SubscribeAsync<T>(string receiverName, string id, string eventType, Func<T, Task> handler)
        {
            var sub = LocalEventBus.Subscribe<LocalEventQueueItem<T>>(async (item) =>
            {
                if (item.IsMatch(receiverName, id, eventType))
                {
                    await handler(item.Payload);
                }
            });
            return Task.FromResult(sub);
        }

        class LocalEventQueueItem<T>
        {
            public string ReceiverName { get; set; }
            public string Id { get; set; }
            public string EventType { get; set; }

            public T Payload { get; set; }

            public bool IsMatch(string receiverName, string id, string eventType)
                => string.Equals(ReceiverName, receiverName)
                && string.Equals(Id, id)
                && string.Equals(EventType, eventType);
        }
    }
}
