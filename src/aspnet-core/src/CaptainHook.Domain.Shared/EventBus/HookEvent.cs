using CaptainHook.Publishers;

namespace CaptainHook.EventBus
{
    public class HookEvent : IHookEventContext
    {
        public string ReceiverName { get; set; }
        public string Id { get; set; }
        public string EventType { get; set; }
        public object Payload { get; set; }

        public bool IsMatch(string receiverName, string id, string eventType)
            => string.Equals(ReceiverName, receiverName)
            && string.Equals(Id, id)
            && string.Equals(EventType, eventType);
    }

    public class HookEventToPublish<T>
    {
        public HookEvent Event { get; }

        public T Payload { get; }

        public HookEventToPublish(HookEvent hookEvent, T payload)
        {
            Event = hookEvent;
            Payload = payload;
        }
    }
}
