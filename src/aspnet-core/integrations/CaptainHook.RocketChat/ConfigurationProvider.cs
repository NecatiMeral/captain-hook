using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.RocketChat
{
    public class ConfigurationProvider : IConfigurationProvider, ITransientDependency
    {
        protected IConfiguration Configuration { get; }

        public ConfigurationProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public RocketChatClientOptions GetConfigurationOrNull(string name, string id)
        {
            var section = Configuration.GetSection($"CaptainHook:{name}:{id}");

            return section.Get<RocketChatClientOptions>();
        }
    }
}
