using System;
using System.Threading.Tasks;

namespace CaptainHook.EventBus
{
    public interface ICaptainHookEventBus
    {
        /// <summary>
        /// Triggers an event.
        /// </summary>
        /// <param name="eventType">Event type</param>
        /// <param name="eventData">Related data for the event</param>
        /// <returns>The task to handle async operation</returns>
        Task PublishAsync(Type eventType, object eventData);
    }
}
