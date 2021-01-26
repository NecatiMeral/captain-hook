using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class RocketChatClient : IRocketChatClient, ITransientDependency
    {
        protected IHttpClientFactory HttpClientFactory { get; }
        protected IRocketChatAuthenticator Authenticator { get; }

        public RocketChatClient(IHttpClientFactory httpClientFactory, IRocketChatAuthenticator authenticator)
        {
            HttpClientFactory = httpClientFactory;
            Authenticator = authenticator;
        }

        public async Task SendMessage(MessageDto message)
        {
            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await Authenticator.AuthenticateAsync(client, message.BaseUrl, message.Username, message.Password);

                var response = await client.PostAsJsonAsync("api/v1/chat.postMessage", message);
                if (!response.IsSuccessStatusCode)
                {

                }
            }
        }
    }
}
