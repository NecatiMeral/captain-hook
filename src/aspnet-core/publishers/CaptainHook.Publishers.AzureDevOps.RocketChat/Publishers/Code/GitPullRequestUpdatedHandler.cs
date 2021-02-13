using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using CaptainHook.EventBus;
using CaptainHook.Receivers.AzureDevOps.Payload;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps;
using System.Linq;
using System;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Publishers.Code
{
    public class GitPullRequestUpdatedHandler : IEventPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatClient { get; }
        protected IObjectMapper ObjectMapper { get; }
        protected IAzureDevOpsService AzureDevOpsService { get; }

        public GitPullRequestUpdatedHandler(IConfigurationProvider configurationProvider,
            IRocketChatClient rocketChatClient,
            IObjectMapper objectMapper,
            IAzureDevOpsService azureDevOpsService)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatClient = rocketChatClient;
            ObjectMapper = objectMapper;
            AzureDevOpsService = azureDevOpsService;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestUpdatedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull(AzureDevOpsRocketChatConsts.PublisherName, eventData.Event.Id);
            if (configuration == null)
            {
                return;
            }

            var payload = eventData.Payload;

            var identities = await AzureDevOpsService.GetAndIterateIdentitiesAsync(
                payload.ResourceContainers.Collection.BaseUrl,
                payload.Resource.Reviewers.Select(x => x.Id).ToArray()
            );

            var mails = identities
                .Select(x => x.Properties.GetOrDefault(AzureDevOpsRocketChatConsts.Identity.MailPropertyName)?.ToString())
                .Where(x => !x.IsNullOrWhiteSpace())
                .ToArray();

            var users = await RocketChatClient.GetUsersByEmailAsync(new GetRocketChatUsersByEmailInputDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Emails = mails
            });

            var repositoryAttachment = new MessageAttachmentDto
            {
                Text = payload.Resource.Description,
                Title = payload.Resource.Title,
                TitleLink = payload.Resource.Url.AbsoluteUri
            };

            // TODO: Determine which users / channels to notify
            // Consider making this configurable (Collection-to-Channel, Project-to-Channel; Team-to-Channel)

            var messageTemplate = new MessageDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Text = payload.Message.Markdown,
                Alias = payload.Resource.CreatedBy.DisplayName,
                Avatar = payload.Resource.CreatedBy.ImageUrl.AbsoluteUri,
                Attachments = new[] { repositoryAttachment }
            };

            foreach (var user in users)
            {
                messageTemplate.Channel = $"@{user.Username}";
                await RocketChatClient.SendMessage(messageTemplate);
            }
        }
    }
}
