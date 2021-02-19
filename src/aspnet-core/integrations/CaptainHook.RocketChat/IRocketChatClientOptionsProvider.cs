using Microsoft.Extensions.Options;

namespace CaptainHook.RocketChat
{
    public interface IRocketChatClientOptionsProvider
    {
        IOptions<RocketChatClientOptions> GetConfigurationOrNull();
    }
}