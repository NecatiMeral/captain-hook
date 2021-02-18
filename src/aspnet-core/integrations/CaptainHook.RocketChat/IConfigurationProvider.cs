namespace CaptainHook.RocketChat
{
    public interface IConfigurationProvider
    {
        RocketChatClientOptions GetConfigurationOrNull(string name, string id);
    }
}