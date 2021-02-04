using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.EventBus;
using CaptainHook.Receivers.AzureDevOps.Payload;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    public class GitPullRequestUpdatedHandler : ITransientDependency, IEventPublisher<GitPullRequestUpdatedPayload>
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatWebHookClient { get; }

        public GitPullRequestUpdatedHandler(IConfigurationProvider configurationProvider, IRocketChatClient rocketChatWebHookClient)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatWebHookClient = rocketChatWebHookClient;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestUpdatedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull("RocketChat", eventData.Event.Id);
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

            await RocketChatWebHookClient.SendMessage(message);
        }
    }
}
