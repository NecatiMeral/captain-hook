namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    public interface IConfigurationProvider
    {
        RocketChatApiOptions GetConfigurationOrNull(string name, string id);
    }
}