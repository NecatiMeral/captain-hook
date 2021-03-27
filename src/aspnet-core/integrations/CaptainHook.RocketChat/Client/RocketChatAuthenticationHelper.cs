using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.RocketChat.Client
{
    static class RocketChatAuthenticationHelper
    {
        public static Task<bool> AuthenticateAsync(HttpClient httpClient, RocketChatClientAuthentication auth)
        {
            httpClient.BaseAddress = new Uri(auth.BaseUrl.EnsureEndsWith('/'));
            httpClient.DefaultRequestHeaders.Add("X-User-ID", auth.UserId);
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", auth.AuthToken);

            return Task.FromResult(true);
        }
    }
}
