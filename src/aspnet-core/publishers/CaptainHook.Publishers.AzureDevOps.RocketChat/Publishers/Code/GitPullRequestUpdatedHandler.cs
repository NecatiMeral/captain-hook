using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.EventBus;
using CaptainHook.Receivers.AzureDevOps.Payload;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Publishers.Code
{
    public class GitPullRequestUpdatedHandler : IEventPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatClient { get; }
        protected IObjectMapper ObjectMapper { get; }

        public GitPullRequestUpdatedHandler(IConfigurationProvider configurationProvider,
            IRocketChatClient rocketChatClient,
            IObjectMapper objectMapper)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatClient = rocketChatClient;
            ObjectMapper = objectMapper;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestUpdatedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull(AzureDevOpsRocketChatConsts.PublisherName, eventData.Event.Id);
            if (configuration == null)
            {
                return;
            }

            var payload = eventData.Payload;
            var repositoryAttachment = new MessageAttachmentDto
            {
                Text = payload.Resource.Description,
                Title = payload.Resource.Title,
                TitleLink = payload.Resource.Url.AbsoluteUri
            };

            // TODO: Determine which users / channels to notify
            // Consider making this configurable (Collection-to-Channel, Project-to-Channel; Team-to-Channel)

            var message = new MessageDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Text = payload.Message.Markdown,
                Alias = payload.Resource.CreatedBy.DisplayName,
                Avatar = payload.Resource.CreatedBy.ImageUrl.AbsoluteUri,
                Channel = "@nm",
                Attachments = new[] { repositoryAttachment }
            };

            await RocketChatClient.SendMessage(message);
        }
    }
}
