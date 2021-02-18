using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers
{
    public class ConfigurationProvider : IConfigurationProvider, ITransientDependency
    {
        protected IConfiguration Configuration { get; }

        public ConfigurationProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public RocketChatApiOptions GetConfigurationOrNull(string name, string id)
        {
            var section = Configuration.GetSection($"CaptainHook:{name}:{id}");

            return section.Get<RocketChatApiOptions>();
        }
    }
}
