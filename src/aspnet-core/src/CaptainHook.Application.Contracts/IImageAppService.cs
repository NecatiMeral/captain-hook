using CaptainHook.Images;
using System.Threading.Tasks;

namespace CaptainHook
{
    public interface IImageAppService
    {
        Task<ImageDto> GetImageAsync(string providerName, string imageId);
    }
}
