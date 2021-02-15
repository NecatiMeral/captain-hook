using CaptainHook.Images;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Http;

namespace CaptainHook
{
    [RemoteService(Name = CaptainHookRemoteServiceConsts.RemoteServiceName)]
    [Area("images")]
    [ControllerName("Images")]
    [Route("api/images")]
    public class ImageController : CaptainHookController, IImageAppService
    {
        protected IImageAppService ImageAppService { get; }

        public ImageController(IImageAppService imageAppService)
        {
            ImageAppService = imageAppService;
        }

        [HttpGet]
        [Route("{providerName}/{imageId}")]
        public async Task<ImageDto> GetImageAsync(string providerName, string imageId)
        {
            return await ImageAppService.GetImageAsync(providerName, imageId);
        }

        [HttpGet]
        [Route("show/{providerName}/{imageId}")]
        public async Task<FileResult> GetImageToDisplayAsync(string providerName, string imageId)
        {
            var image = await ImageAppService.GetImageAsync(providerName, imageId);

            return File(image.Payload, image.MediaType);
        }
    }
}
