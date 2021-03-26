using CaptainHook.Publishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.RocketChat
{
    public class RocketChatClientOptionsProvider : IRocketChatClientOptionsProvider, IScopedDependency
    {
        protected IHookEventContextProvider HookEventContextProvider { get; }
        protected IConfiguration Configuration { get; }

        public RocketChatClientOptionsProvider(IHookEventContextProvider hookEventContextProvider, IConfiguration configuration)
        {
            HookEventContextProvider = hookEventContextProvider;
            Configuration = configuration;
        }

        public IOptions<RocketChatClientOptions> GetConfigurationOrNull()
        {
            var context = HookEventContextProvider.GetContext();
            var section = Configuration.GetSection($"CaptainHook:RocketChat:{context.Id}");

            return Options.Create(section.Get<RocketChatClientOptions>());
        }
    }
}
