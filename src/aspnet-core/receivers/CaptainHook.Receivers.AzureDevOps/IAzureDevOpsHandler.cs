using System.Threading.Tasks;

namespace CaptainHook.Receivers.AzureDevOps
{
    interface IAzureDevOpsHandler
    {
        Task<object> HandleAsync(IWebHookExecutionContext context);
    }
}