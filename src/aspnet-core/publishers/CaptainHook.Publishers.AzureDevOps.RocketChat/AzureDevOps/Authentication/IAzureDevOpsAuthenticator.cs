using Microsoft.VisualStudio.Services.Common;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps.Authentication
{
    public interface IAzureDevOpsAuthenticator
    {
        Task<VssCredentials> CreateCredentials();
    }
}
