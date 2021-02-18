using CaptainHook.EventBus;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using System.Linq;
using CaptainHook.AzureDevOps.RocketChat.Publisher.Services;
using CaptainHook.Images;
using CaptainHook.Publishers;
using CaptainHook.AzureDevOps.Payload;
using CaptainHook.AzureDevOps.Images;
using CaptainHook.RocketChat;

namespace CaptainHook.AzureDevOps.RocketChat.Publisher.Code
{
    public class GitPullRequestUpdatedHandler : IEventPublisher<GitPullRequestUpdatedPayload>, ITransientDependency
    {
        protected IConfigurationProvider ConfigurationProvider { get; }
        protected IRocketChatClient RocketChatClient { get; }
        protected IIdentityToChatUserMapper IdentityToChatUserMapper { get; }
        protected IImageUriFactory ImageUriFactory { get; }

        public GitPullRequestUpdatedHandler(IConfigurationProvider configurationProvider,
            IRocketChatClient rocketChatClient,
            IIdentityToChatUserMapper identityToChatUserMapper,
            IImageUriFactory imageUriFactory)
        {
            ConfigurationProvider = configurationProvider;
            RocketChatClient = rocketChatClient;
            IdentityToChatUserMapper = identityToChatUserMapper;
            ImageUriFactory = imageUriFactory;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestUpdatedPayload> eventData)
        {
            var configuration = ConfigurationProvider.GetConfigurationOrNull(AzureDevOpsRocketChatConsts.PublisherName, eventData.Event.Id);
            if (configuration == null)
            {
                return;
            }

            var payload = eventData.Payload;

            var users = await IdentityToChatUserMapper.GetUsersAsync(
                payload.ResourceContainers.Collection.BaseUrl,
                payload.Resource.Reviewers.Select(x => x.Id).ToArray(),
                new RocketChatInputDto
                {
                    BaseUrl = configuration.BaseUrl,
                    Username = configuration.Username,
                    Password = configuration.Password
                }
            );

            // TODO: Determine which users / channels to notify
            // Consider making this configurable (Collection-to-Channel, Project-to-Channel; Team-to-Channel)
            var avatarId = IdentityImageProvider.GetImageId(payload.Resource.CreatedBy.ImageUrl);
            var avatarUri = await ImageUriFactory.GetImageUriAsync(AzureDevOpsConstants.ReceiverName, avatarId);

            var messageTemplate = new MessageDto
            {
                BaseUrl = configuration.BaseUrl,
                Username = configuration.Username,
                Password = configuration.Password,
                Text = payload.Message.Markdown,
                Alias = payload.Resource.CreatedBy.DisplayName,
                Avatar = avatarUri.AbsoluteUri
            };

            foreach (var user in users)
            {
                messageTemplate.Channel = $"@{user.Username}";
                await RocketChatClient.SendMessage(messageTemplate);
            }
        }
    }
}
