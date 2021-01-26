using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.Receivers;
using CaptainHook.Receivers.AzureDevOps.Payload;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat
{
    public class GitPullRequestUpdatedHandler
        : ILocalEventHandler<WebHookHandledEvent<GitPullRequestUpdatedPayload>>,
          ITransientDependency
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatWebHookClient { get; }

        public GitPullRequestUpdatedHandler(IConfigurationProvider configurationProvider, IRocketChatClient rocketChatWebHookClient)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatWebHookClient = rocketChatWebHookClient;
        }

        public async Task HandleEventAsync(WebHookHandledEvent<GitPullRequestUpdatedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull(eventData.Name, eventData.Id);
            if (configuration == null)
            {
                return;
            }

            var repositoryAttachment = new MessageAttachmentDto
            {
                Text = eventData.Payload.Resource.Description,
                Title = eventData.Payload.Resource.Title,
                TitleLink = eventData.Payload.Resource.Url.AbsoluteUri
            };

            var message = new MessageDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Text = eventData.Payload.Message.Markdown,
                Alias = eventData.Payload.Resource.CreatedBy.DisplayName,
                Avatar = eventData.Payload.Resource.CreatedBy.ImageUrl.AbsoluteUri,
                Channel = "@nm",
                Attachments = new[] { repositoryAttachment }
            };

            await RocketChatWebHookClient.SendMessage(message);
        }
    }
}
