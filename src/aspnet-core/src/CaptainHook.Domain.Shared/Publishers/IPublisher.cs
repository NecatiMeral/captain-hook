using System.Threading.Tasks;

namespace CaptainHook.Publishers
{
    public interface IPublisher<in TEvent> : IPublisher
    {
        Task HandleEventAsync(TEvent eventData);
    }

    public interface IPublisher
    {
    }
}
