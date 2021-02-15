using System;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public interface IAzureDevOpsService
    {
        Task<AzureDevOpsIdentityDto> GetIdentityAsync(Uri collectionUri, Guid identityId);
        Task<AzureDevOpsIdentityDto[]> GetIdentitiesAsync(Uri collectionUri, Guid[] identityIds);
        Task<AzureDevOpsIdentityDto[]> GetAndIterateIdentitiesAsync(Uri collectionUri, Guid[] identityIds);
        Task<IdentityImageDto> DownloadIdentityImageAsync(Uri collectionUri, Guid identityId);
    }
}