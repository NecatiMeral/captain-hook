using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps;
using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Services
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

        public async Task<RocketChatUserDto[]> GetUsersAsync(Uri azureDevOpsBaseUri, Guid[] identityIds, RocketChatInputDto rocketChatParams)
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
                BaseUrl = rocketChatParams.BaseUrl,
                Username = rocketChatParams.Username,
                Password = rocketChatParams.Password,
                Emails = mails
            });
        }
    }
}
