using CaptainHook.RocketChat;
using System;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.RocketChat.Publisher.Services
{
    public interface IIdentityToChatUserMapper
    {
        Task<RocketChatUserDto[]> GetUsersAsync(Uri azureDevOpsBaseUri, Guid[] identities, RocketChatInputDto rocketChatParams);
    }
}
