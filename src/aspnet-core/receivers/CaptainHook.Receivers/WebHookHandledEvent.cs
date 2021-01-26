namespace CaptainHook.Receivers
{
    public class WebHookHandledEvent<T> : WebHookHandledEvent
    {
        public T Payload { get; set; }
    }

    public class WebHookHandledEvent
    {
        public string Name { get; set; }

        public string Id { get; set; }
    }
}
