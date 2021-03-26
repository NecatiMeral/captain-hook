using CaptainHook.WebHooks;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.Receiver
{
    interface IAzureDevOpsHandler
    {
        Task<object> HandleAsync(IWebHookExecutionContext context);
    }
}