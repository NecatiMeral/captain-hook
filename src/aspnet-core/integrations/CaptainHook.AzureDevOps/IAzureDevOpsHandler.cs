using CaptainHook.WebHooks;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps
{
    interface IAzureDevOpsHandler
    {
        Task<object> HandleAsync(IWebHookExecutionContext context);
    }
}