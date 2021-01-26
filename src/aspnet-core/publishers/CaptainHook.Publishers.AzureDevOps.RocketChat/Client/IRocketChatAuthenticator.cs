using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public interface IRocketChatAuthenticator
    {
        Task<bool> AuthenticateAsync(HttpClient httpClient, string baseUrl, string username, string password);
        Task SignOffAsync();
    }
}