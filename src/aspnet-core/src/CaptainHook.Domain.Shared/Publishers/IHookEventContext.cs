namespace CaptainHook.Publishers
{
    public interface IHookEventContext
    {
        string ReceiverName { get; }
        string Id { get; }
        string EventType { get; }
        object Payload { get; }
    }
}
