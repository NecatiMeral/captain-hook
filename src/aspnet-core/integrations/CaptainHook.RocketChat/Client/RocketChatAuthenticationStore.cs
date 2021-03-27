using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.RocketChat.Client
{
    public class RocketChatAuthenticationStore : IRocketChatAuthenticationStore, ISingletonDependency
    {
        Dictionary<string, RocketChatClientAuthentication> authenticationMap;

        protected IRocketChatPresenceService PresenceService { get; }

        public RocketChatAuthenticationStore(IRocketChatPresenceService rocketChatPresenceService)
        {
            authenticationMap = new Dictionary<string, RocketChatClientAuthentication>();
            PresenceService = rocketChatPresenceService;
        }
        public void AddTokenRegistration(RocketChatClientAuthentication auth)
        {
            var key = RocketChatClientAuthentication.CalculateCacheKey(auth.BaseUrl, auth.Username);
            if (!authenticationMap.ContainsKey(key))
            {
                authenticationMap.Add(key, auth);
            }
        }

        public async Task SignOffAsync()
        {
            foreach (var pair in authenticationMap)
            {
                await PresenceService.SignOffAsync(pair.Value);
            }
        }
    }
}
