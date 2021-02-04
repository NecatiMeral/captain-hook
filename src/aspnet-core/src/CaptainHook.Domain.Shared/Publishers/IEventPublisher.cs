using CaptainHook.EventBus;
using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    /// <summary>
    /// Should be implemented by event publishers to receive, process and publish incoming events.
    /// </summary>
    public interface IEventPublisher<T> : IEventPublisher
    {

        /// <summary>
        /// Handler handles the event by implementing this method.
        /// </summary>
        /// <param name="eventData">Event data (including event data aswell the parsed payload)</param>
        Task HandleEventAsync(HookEventToPublish<T> eventData);
    }

    /// <summary>
    /// Undirect base interface for all event publishers.
    /// Implement <see cref="IEventPublisher{TEvent}"/> instead of this one.
    /// </summary>
    public interface IEventPublisher
    {

    }
}
