namespace CaptainHook.Receivers
{
    public interface IWebHookExecutionContext
    {
        string Name { get; }
        string Id { get; }
        dynamic Content { get; }
    }
}
