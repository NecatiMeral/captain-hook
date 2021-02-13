using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public interface IAzureDevOpsConnectionAccessor
    {
        Task<VssConnection> GetConnectionAsync(Uri collectionUri);
    }
}
