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
    public class GitPullRequestCreatedHandler : IEventPublisher<GitPullRequestCreatedPayload>, IScopedDependency
    {
        protected IRocketChatClient RocketChatClient { get; }
        protected IIdentityToChatUserMapper IdentityToChatUserMapper { get; }
        protected IImageUriFactory ImageUriFactory { get; }

        public GitPullRequestCreatedHandler(
            IRocketChatClient rocketChatClient,
            IIdentityToChatUserMapper identityToChatUserMapper,
            IImageUriFactory imageUriFactory)
        {
            RocketChatClient = rocketChatClient;
            IdentityToChatUserMapper = identityToChatUserMapper;
            ImageUriFactory = imageUriFactory;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestCreatedPayload> eventData)
        {
            var payload = eventData.Payload;
            var users = await IdentityToChatUserMapper.GetUsersAsync(
                payload.ResourceContainers.Collection.BaseUrl,
                payload.Resource.Reviewers.Select(x => x.Id).ToArray()
            );

            // TODO: Determine which users / channels to notify
            // Consider making this configurable (Collection-to-Channel, Project-to-Channel; Team-to-Channel)
            var avatarId = IdentityImageProvider.GetImageId(payload.Resource.CreatedBy.ImageUrl);
            var avatarUri = await ImageUriFactory.GetImageUriAsync(AzureDevOpsConstants.ReceiverName, avatarId);

            var messageTemplate = new MessageDto
            {
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
