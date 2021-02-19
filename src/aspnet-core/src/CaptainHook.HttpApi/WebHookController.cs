using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace CaptainHook
{
    [RemoteService(Name = CaptainHookRemoteServiceConsts.RemoteServiceName)]
    [Area("webhooks")]
    [ControllerName("Incoming")]
    [Route("api/webhook")]
    public class WebHookController : CaptainHookController, IIncomingWebHookAppService
    {
        protected IIncomingWebHookAppService IncomingWebHookAppService { get; }

        public WebHookController(IIncomingWebHookAppService incomingWebHookAppService)
        {
            IncomingWebHookAppService = incomingWebHookAppService;
        }

        [HttpPost]
        [Route("incoming/{name}/{id}")]
        public async Task<object> ReceiveAsync(string name, string id, [FromBody] dynamic content)
        {
            return await IncomingWebHookAppService.ReceiveAsync(name, id, content);
        }
    }
}
