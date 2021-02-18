using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Client
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
        /// <param name="baseUrl">The base-url of the rocket chat server to use.</param>
        /// <param name="username">The username to use.</param>
        /// <param name="password">The user's password to use.</param>
        /// <returns></returns>
        Task<bool> AuthenticateAsync(HttpClient httpClient, string baseUrl, string username, string password);
        
        /// <summary>
        /// Exits the current RocketChat session and logs the current user out.
        /// </summary>
        /// <returns></returns>
        Task SignOffAsync();
    }
}