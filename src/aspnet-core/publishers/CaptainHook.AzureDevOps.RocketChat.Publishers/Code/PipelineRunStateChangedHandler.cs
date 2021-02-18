using CaptainHook.EventBus;
using CaptainHook.AzureDevOps.RocketChat.Publishers.Client;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using CaptainHook.AzureDevOps.Payload;
using CaptainHook.Publishers;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Code
{
    public class PipelineRunStateChangedHandler : IEventPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatWebHookClient { get; }

        public PipelineRunStateChangedHandler(IConfigurationProvider configurationProvider, IRocketChatClient rocketChatWebHookClient)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatWebHookClient = rocketChatWebHookClient;
        }

        public async Task HandleEventAsync(HookEventToPublish<PipelineRunStateChangedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull(AzureDevOpsRocketChatConsts.PublisherName, eventData.Event.Id);
            if (configuration == null)
            {
                return;
            }

            var payload = eventData.Payload;

            var message = new MessageDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Text = payload.Message.Markdown,
                Channel = "@nm"
            };

            await RocketChatWebHookClient.SendMessage(message);
        }
    }
}
