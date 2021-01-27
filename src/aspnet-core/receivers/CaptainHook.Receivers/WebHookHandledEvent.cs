namespace CaptainHook.Receivers
{
    public class WebHookHandledEvent<T> : WebHookHandledEvent
    {
        public T Payload { get; set; }
    }

    public class WebHookHandledEvent
    {
        public string ReceiverName { get; set; }

        public string EventType { get; set; }

        public string Id { get; set; }
    }
}
