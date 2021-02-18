using CaptainHook.AzureDevOps.RocketChat.Publishers.Client;
using System;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Services
{
    public interface IIdentityToChatUserMapper
    {
        Task<RocketChatUserDto[]> GetUsersAsync(Uri azureDevOpsBaseUri, Guid[] identities, RocketChatInputDto rocketChatParams);
    }
}
