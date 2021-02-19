using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.RocketChat
{
    /// <summary>
    /// Controls user authentication
    /// </summary>
    public interface IRocketChatAuthenticator
    {
        /// <summary>
        /// Authenticates the given <see cref="HttpClient"/> instance by using the given options.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to authenticate.</param>
        /// <returns></returns>
        Task<bool> AuthenticateAsync(HttpClient httpClient);
        
        /// <summary>
        /// Exits the current RocketChat session and logs the current user out.
        /// </summary>
        /// <returns></returns>
        Task SignOffAsync();
    }
}