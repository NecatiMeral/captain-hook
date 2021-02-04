using CaptainHook.EventBus;
using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.Receivers.AzureDevOps.Payload;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
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
