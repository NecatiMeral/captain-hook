using CaptainHook.Publishers.AzureDevOps.RocketChat.Client;
using System;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Services
{
    public interface IIdentityToChatUserMapper
    {
        Task<RocketChatUserDto[]> GetUsersAsync(Uri azureDevOpsBaseUri, Guid[] identities, RocketChatInputDto rocketChatParams);
    }
}
