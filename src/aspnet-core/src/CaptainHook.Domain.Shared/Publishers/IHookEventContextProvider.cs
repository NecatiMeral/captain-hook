namespace CaptainHook.Publishers
{
    public interface IHookEventContextProvider
    {
        void SetContext(IHookEventContext context);

        IHookEventContext GetContext();
    }
}
