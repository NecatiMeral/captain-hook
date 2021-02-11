using Microsoft.VisualStudio.Services.WebApi;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public interface IAzureDevOpsConnectionAccessor
    {
        VssConnection GetConnection();
    }
}
