using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace CaptainHook
{
    [RemoteService(Name = CaptainHookRemoteServiceConsts.RemoteServiceName)]
    [Area("webhooks")]
    [ControllerName("Incoming")]
    [Route("api/webhook/incoming")]
    public class IncomingWebHookController : CaptainHookController, IIncomingWebHookAppService
    {
        protected IIncomingWebHookAppService IncomingWebHookAppService { get; }

        public IncomingWebHookController(IIncomingWebHookAppService incomingWebHookAppService)
        {
            IncomingWebHookAppService = incomingWebHookAppService;
        }

        [HttpPost]
        [Route("{name}/{id}")]
        public async Task ReceiveAsync(string name, string id, [FromBody] dynamic content)
        {
            await IncomingWebHookAppService.ReceiveAsync(name, id, content);
        }
    }
}
