using System.Threading.Tasks;

namespace CaptainHook.RocketChat.Client
{
    public interface IRocketChatPresenceService
    {
        Task SetUserPresenceAsync(RocketChatClientAuthentication auth, string status, string message);

        /// <summary>
        /// Exits the current RocketChat session and logs the current user out.
        /// </summary>
        /// <returns></returns>
        Task SignOffAsync(RocketChatClientAuthentication auth);
    }
}