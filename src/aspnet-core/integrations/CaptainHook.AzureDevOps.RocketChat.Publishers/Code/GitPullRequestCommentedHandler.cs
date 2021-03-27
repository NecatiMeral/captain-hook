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
    public class GitPullRequestCommentedHandler : IEventPublisher<GitPullRequestCommentedPayload>, IScopedDependency
    {
        protected IRocketChatClient RocketChatClient { get; }
        protected IIdentityToChatUserMapper IdentityToChatUserMapper { get; }
        protected IImageUriFactory ImageUriFactory { get; }

        public GitPullRequestCommentedHandler(
            IRocketChatClient rocketChatClient,
            IIdentityToChatUserMapper identityToChatUserMapper,
            IImageUriFactory imageUriFactory)
        {
            RocketChatClient = rocketChatClient;
            IdentityToChatUserMapper = identityToChatUserMapper;
            ImageUriFactory = imageUriFactory;
        }

        public async Task HandleEventAsync(HookEventToPublish<GitPullRequestCommentedPayload> eventData)
        {
            var payload = eventData.Payload;
            var users = await IdentityToChatUserMapper.GetUsersAsync(
                payload.ResourceContainers.Collection.BaseUrl,
                payload.Resource.PullRequest.Reviewers.Select(x => x.Id).ToArray()
            );

            // TODO: Determine which users / channels to notify
            // Consider making this configurable (Collection-to-Channel, Project-to-Channel; Team-to-Channel)
            var avatarId = IdentityImageProvider.GetImageId(payload.Resource.Comment.Author.ImageUrl);
            var avatarUri = await ImageUriFactory.GetImageUriAsync(AzureDevOpsConstants.ReceiverName, avatarId);

            var messageTemplate = new MessageDto
            {
                Text = payload.DetailedMessage.Markdown,
                Alias = payload.Resource.Comment.Author.DisplayName,
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
