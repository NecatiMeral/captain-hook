using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class RocketChatClient : IRocketChatClient, ITransientDependency
    {
        protected IHttpClientFactory HttpClientFactory { get; }
        protected IRocketChatAuthenticator Authenticator { get; }
        protected IDistributedCache<RocketChatUserDto> UserCache { get; }
        protected IJsonSerializer JsonSerializer { get; }

        public RocketChatClient(IHttpClientFactory httpClientFactory,
            IRocketChatAuthenticator authenticator,
            IDistributedCache<RocketChatUserDto> userCache,
            IJsonSerializer jsonSerializer)
        {
            HttpClientFactory = httpClientFactory;
            Authenticator = authenticator;
            UserCache = userCache;
            JsonSerializer = jsonSerializer;
        }

        public async Task SendMessage(MessageDto message)
        {
            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await Authenticator.AuthenticateAsync(client, message.BaseUrl, message.Username, message.Password);

                var payload = JsonSerializer.Serialize(message);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/v1/chat.postMessage", content);
                if (!response.IsSuccessStatusCode)
                {
                    var contentMessage = await response.Content.ReadAsStringAsync();
                    throw new InvalidOperationException(contentMessage);
                }
            }
        }

        string CalculateUserKey(string email) => email.ToLowerInvariant().Normalize();

        public async Task<RocketChatUserDto> GetUserByEmailAsync(GetRocketChatUserByEmailInputDto input)
        {
            return await UserCache.GetOrAddAsync(
                CalculateUserKey(input.Email),
                () => GetUserByEmailFromApiAsync(input)
            );
        }

        public async Task<RocketChatUserDto[]> GetUsersByEmailAsync(GetRocketChatUsersByEmailInputDto input)
        {
            var cacheKeys = input.Emails.Select(CalculateUserKey).ToArray();

            var cachedUsers = await UserCache.GetManyAsync(cacheKeys);
            var users = cachedUsers.Select(x => x.Value).OfType<RocketChatUserDto>().ToList().ToList();
            var missingUserKeys = cacheKeys
                .Where(x => !users.Any(i => i.Emails != null && i.Emails.Any(e => string.Equals(e.Address, x, StringComparison.OrdinalIgnoreCase))))
                .ToArray();

            if (missingUserKeys.Any())
            {
                var query = new GetRocketChatUsersByEmailInputDto
                {
                    BaseUrl = input.BaseUrl,
                    Username = input.Username,
                    Password = input.Password,
                    Emails = missingUserKeys
                };

                var missingUsers = await GetUsersByEmailFromApiAsync(query);

                var cacheItems = missingUsers
                    .Select(x => new KeyValuePair<string, RocketChatUserDto>(CalculateUserKey(GetVerifiedOrFirstEmail(x)), x))
                    .ToArray();

                await UserCache.SetManyAsync(cacheItems);

                users.AddRange(missingUsers);
            }

            return users.ToArray();
        }

        static string GetVerifiedOrFirstEmail(RocketChatUserDto user)
        {
            var verified = user.Emails.FirstOrDefault(x => x.Verified);

            return verified != null
                ? verified.Address
                : user.Emails.FirstOrDefault()?.Address;
        }

        async Task<RocketChatUserDto[]> GetUsersByEmailFromApiAsync(GetRocketChatUsersByEmailInputDto input)
        {
            // TODO: Create a proper filter query. For now it's easier to just fetch all users
            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await Authenticator.AuthenticateAsync(client, input.BaseUrl, input.Username, input.Password);

                var response = await client.GetFromJsonAsync<UserListResponse>("api/v1/users.list");

                return response.Users
                    .Where(user => user.Emails != null
                        && user.Emails.Any(email => input.Emails.Contains(email.Address, StringComparer.OrdinalIgnoreCase)))
                    .ToArray();
            }
        }

        async Task<RocketChatUserDto> GetUserByEmailFromApiAsync(GetRocketChatUserByEmailInputDto input)
        {
            // To query data on the rocket chat API, we have to use the mongo-db query operators
            // See https://stackoverflow.com/questions/10700921/case-insensitive-search-with-in
            const string queryTemplate = "query={\"emails\":{\"$elemMatch\": {\"address\" : {\"$regex\":\"{0}\", \"$options\": \"i\"}}}}";

            using (var client = HttpClientFactory.CreateClient("RocketChat"))
            {
                await Authenticator.AuthenticateAsync(client, input.BaseUrl, input.Username, input.Password);

                var queryParameter = string.Format(queryTemplate, input.Email);
                var response = await client.GetFromJsonAsync<UserListResponse>($"api/v1/users.list?{queryParameter}");

                return response.Users.FirstOrDefault();
            }
        }

        class UserListResponse
        {
            [JsonPropertyName("users")]
            public RocketChatUserDto[] Users { get; set; }
        }
    }
}
