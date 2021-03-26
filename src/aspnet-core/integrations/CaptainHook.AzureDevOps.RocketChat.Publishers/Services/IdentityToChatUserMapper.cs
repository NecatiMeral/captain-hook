using CaptainHook.AzureDevOps.Client;
using CaptainHook.RocketChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.RocketChat.Publisher.Services
{
    public class IdentityToChatUserMapper : IIdentityToChatUserMapper, ITransientDependency
    {
        protected IAzureDevOpsService AzureDevOpsService { get; }
        protected IRocketChatClient RocketChatClient { get; }

        public IdentityToChatUserMapper(IAzureDevOpsService azureDevOpsService, IRocketChatClient rocketChatClient)
        {
            AzureDevOpsService = azureDevOpsService;
            RocketChatClient = rocketChatClient;
        }

        public async Task<RocketChatUserDto[]> GetUsersAsync(Uri azureDevOpsBaseUri, Guid[] identityIds)
        {
            var identities = await AzureDevOpsService.GetAndIterateIdentitiesAsync(
                azureDevOpsBaseUri,
                identityIds
            );

            var mails = identities
                .Select(x => x.Properties.GetOrDefault(AzureDevOpsRocketChatConsts.Identity.MailPropertyName)?.ToString())
                .Where(x => !x.IsNullOrWhiteSpace())
                .ToArray();

            return await RocketChatClient.GetUsersByEmailAsync(new GetRocketChatUsersByEmailInputDto
            {
                Emails = mails
            });
        }
    }
}
