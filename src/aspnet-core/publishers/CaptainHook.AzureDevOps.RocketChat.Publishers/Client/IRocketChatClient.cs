using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Client
{
    public interface IRocketChatClient
    {
        Task SendMessage(MessageDto message);

        Task<RocketChatUserDto> GetUserByEmailAsync(GetRocketChatUserByEmailInputDto input);

        Task<RocketChatUserDto[]> GetUsersByEmailAsync(GetRocketChatUsersByEmailInputDto input);
    }
}