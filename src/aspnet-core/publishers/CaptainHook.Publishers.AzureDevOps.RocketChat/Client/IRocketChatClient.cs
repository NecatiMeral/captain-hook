using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public interface IRocketChatClient
    {
        Task SendMessage(MessageDto message);
    }
}