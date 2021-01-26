using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
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
            var section = Configuration.GetSection($"From:{name}:To:RocketChat.{id}");

            return section.Get<RocketChatApiOptions>();
        }
    }
}
