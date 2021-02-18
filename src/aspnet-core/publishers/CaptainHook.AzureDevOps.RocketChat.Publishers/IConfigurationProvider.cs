namespace CaptainHook.AzureDevOps.RocketChat.Publishers
{
    public interface IConfigurationProvider
    {
        RocketChatApiOptions GetConfigurationOrNull(string name, string id);
    }
}