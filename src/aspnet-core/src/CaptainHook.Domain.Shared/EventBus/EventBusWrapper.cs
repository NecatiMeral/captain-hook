using System;
using System.Threading.Tasks;
using Volo.Abp.EventBus;

namespace CaptainHook.EventBus
{
    public abstract class EventBusWrapper : ICaptainHookEventBus
    {
        protected IEventBus EventBus { get; }

        public EventBusWrapper(IEventBus eventBus)
        {
            EventBus = eventBus;
        }

        public Task PublishAsync(Type eventType, object eventData)
            => EventBus.PublishAsync(eventType, eventData);
    }
}
