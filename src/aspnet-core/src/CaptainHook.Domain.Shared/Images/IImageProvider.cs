using System.Threading.Tasks;

namespace CaptainHook.Images
{
    public interface IImageProvider
    {
        Task<bool> IsSatisfiedByAsync(string providerKey);

        Task<ImageDto> GetImageAsync(string imageId);
    }
}
