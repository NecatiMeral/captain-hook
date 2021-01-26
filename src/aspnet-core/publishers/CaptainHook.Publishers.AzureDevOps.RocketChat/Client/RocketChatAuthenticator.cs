using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class RocketChatAuthenticator : IRocketChatAuthenticator, ISingletonDependency
    {
        readonly Dictionary<string, AuthenticationResult> tokenCache;
        protected IHttpClientFactory HttpClientFactory { get; }

        public RocketChatAuthenticator(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            tokenCache = new Dictionary<string, AuthenticationResult>();
        }

        public async Task<bool> AuthenticateAsync(HttpClient httpClient, string baseUrl, string username, string password)
        {
            var auth = await AuthenticateAsyncImpl(baseUrl, username, password);

            return await AuthenticateImplAsync(httpClient, auth);
        }

        Task<bool> AuthenticateImplAsync(HttpClient httpClient, AuthenticationResult auth)
        {
            httpClient.BaseAddress = new Uri(auth.BaseUrl.EnsureEndsWith('/'));
            httpClient.DefaultRequestHeaders.Add("X-User-ID", auth.UserId);
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", auth.AuthToken);

            return Task.FromResult(true);
        }

        async Task<AuthenticationResult> AuthenticateAsyncImpl(string baseUrl, string username, string password)
        {
            var cacheKey = AuthenticationResult.CalculateCacheKey(baseUrl, username);
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

                    var authResult = new AuthenticationResult
                    {
                        BaseUrl = baseUrl,
                        Username = username,
                        UserId = authenticationResponse.Data.UserId,
                        AuthToken = authenticationResponse.Data.AuthToken
                    };
                    tokenCache[cacheKey] = authResult;

                    await SetUserPresence(authResult, "online", "serving your DevOps notifications.");

                    return authResult;
                }
            }
            throw new Exception("Fix me");
        }

        async Task SetUserPresence(AuthenticationResult auth, string status, string message)
        {
            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await AuthenticateImplAsync(client, auth);

                _ = await client.PostAsJsonAsync("api/v1/users.setStatus", new { message = message, status = status });
            }
        }

        public async Task SignOffAsync()
        {
            foreach (var pair in tokenCache)
            {
                await SetUserPresence(pair.Value, "offline", "404 not found");
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

        class AuthenticationResult
        {
            public string BaseUrl { get; set; }
            public string Username { get; set; }
            public string UserId { get; set; }
            public string AuthToken { get; set; }

            public static string CalculateCacheKey(string baseUrl, string username)
            {
                return $"{baseUrl}-{username}";
            }
        }
    }
}
