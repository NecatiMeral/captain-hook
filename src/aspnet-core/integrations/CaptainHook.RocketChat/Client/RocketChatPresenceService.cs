using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.RocketChat.Client
{
    public class RocketChatPresenceService : IRocketChatPresenceService, ITransientDependency
    {
        protected IHttpClientFactory HttpClientFactory { get; }

        public RocketChatPresenceService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task SetUserPresenceAsync(RocketChatClientAuthentication auth, string status, string message)
        {
            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await RocketChatAuthenticationHelper.AuthenticateAsync(client, auth);

                _ = await client.PostAsJsonAsync("api/v1/users.setStatus", new { message = message, status = status });
            }
        }

        // TODO: Refactor this out of the authenticator
        public async Task SignOffAsync(RocketChatClientAuthentication auth)
        {
            await SetUserPresenceAsync(auth, "offline", "404 not found");
        }
    }
}
