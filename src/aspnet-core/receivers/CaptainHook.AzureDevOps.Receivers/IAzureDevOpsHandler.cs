using CaptainHook.WebHooks;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.Receivers
{
    interface IAzureDevOpsHandler
    {
        Task<object> HandleAsync(IWebHookExecutionContext context);
    }
}