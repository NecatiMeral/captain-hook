using System.Threading.Tasks;

namespace CaptainHook.RocketChat.Client
{
    public interface IRocketChatAuthenticationStore
    {
        void AddTokenRegistration(RocketChatClientAuthentication auth);

        Task SignOffAsync();
    }
}
