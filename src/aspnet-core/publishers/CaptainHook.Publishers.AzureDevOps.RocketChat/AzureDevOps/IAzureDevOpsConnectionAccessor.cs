using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public interface IAzureDevOpsConnectionAccessor
    {
        Task<VssConnection> GetConnectionAsync(Uri collectionUri);
        Task<HttpClient> CreateHttpClientAsync(Uri collectionUri);
    }
}
