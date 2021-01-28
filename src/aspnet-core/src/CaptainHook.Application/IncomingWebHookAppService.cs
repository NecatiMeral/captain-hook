using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CaptainHook
{
    public class IncomingWebHookAppService : ApplicationService, IIncomingWebHookAppService
    {
        protected IWebHookService WebHookService { get; }

        public IncomingWebHookAppService(IWebHookService webHookService)
        {
            WebHookService = webHookService;
        }

        public async Task<object> ReceiveAsync(string name, string id, dynamic content)
        {
            Logger.LogInformation(1,
                $"{ nameof(IncomingWebHookAppService)} / '{{Name}}' received '{{Id}}'.",
                name,
                id);

            return await WebHookService.ProcessAsync(name, id, content);
        }
    }
}
