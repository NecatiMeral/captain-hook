using CaptainHook.RocketChat.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.RocketChat
{
    public class RocketChatAuthenticator : IRocketChatAuthenticator, IScopedDependency
    {
        readonly Dictionary<string, RocketChatClientAuthentication> tokenCache;
        protected IHttpClientFactory HttpClientFactory { get; }
        protected IRocketChatAuthenticationStore AuthenticationStore { get; }
        protected IRocketChatClientOptionsProvider ClientOptionsProvider { get; }
        protected IRocketChatPresenceService PresenceService { get; }

        public RocketChatAuthenticator(IHttpClientFactory httpClientFactory,
            IRocketChatAuthenticationStore rocketChatAuthenticationStore,
            IRocketChatClientOptionsProvider rocketChatClientOptionsProvider,
            IRocketChatPresenceService rocketChatPresenceService)
        {
            HttpClientFactory = httpClientFactory;
            AuthenticationStore = rocketChatAuthenticationStore;
            ClientOptionsProvider = rocketChatClientOptionsProvider;
            PresenceService = rocketChatPresenceService;
            tokenCache = new Dictionary<string, RocketChatClientAuthentication>();
        }

        public async Task<bool> AuthenticateAsync(HttpClient httpClient)
        {
            var options = ClientOptionsProvider.GetConfigurationOrNull().Value;
            var auth = await AuthenticateAsyncImpl(options.BaseUrl, options.Username, options.Password);

            return await RocketChatAuthenticationHelper.AuthenticateAsync(httpClient, auth);
        }

        async Task<RocketChatClientAuthentication> AuthenticateAsyncImpl(string baseUrl, string username, string password)
        {
            var cacheKey = RocketChatClientAuthentication.CalculateCacheKey(baseUrl, username);
            if (tokenCache.ContainsKey(cacheKey))
            {
                return tokenCache[cacheKey];
            }

            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                client.BaseAddress = new Uri(baseUrl.EnsureEndsWith('/'));

                var jsonPayload = new
                {
                    user = username,
                    password = password
                };

                var response = await client.PostAsJsonAsync("api/v1/login", jsonPayload);
                if (response.IsSuccessStatusCode)
                {
                    var authenticationResponse = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();

                    var authResult = new RocketChatClientAuthentication
                    {
                        BaseUrl = baseUrl,
                        Username = username,
                        UserId = authenticationResponse.Data.UserId,
                        AuthToken = authenticationResponse.Data.AuthToken
                    };
                    tokenCache[cacheKey] = authResult;

                    await PresenceService.SetUserPresenceAsync(authResult, "online", "serving your DevOps notifications");

                    AuthenticationStore.AddTokenRegistration(authResult);
                    return authResult;
                }
                else
                {
                    var message = string.Format("Failed to authenticate `{0}` @ `{1}`", username, baseUrl);
                    throw new ApplicationException(message);
                }
            }
        }

        class AuthenticationResponse
        {
            [JsonPropertyName("status")]
            public string Status { get; set; }

            [JsonPropertyName("data")]
            public AuthenticationData Data { get; set; }
        }

        class AuthenticationData
        {
            [JsonPropertyName("authToken")]
            public string AuthToken { get; set; }

            [JsonPropertyName("userId")]
            public string UserId { get; set; }
        }
    }
}
