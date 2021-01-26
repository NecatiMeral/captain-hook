using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task ReceiveAsync(string name, string id, dynamic content)
        {
            Logger.LogInformation(1,
                $"{ nameof(IncomingWebHookAppService)} / '{{Name}}' received '{{Id}}'.",
                name,
                id);

            await WebHookService.ProcessAsync(name, id, content);
        }
    }
}
