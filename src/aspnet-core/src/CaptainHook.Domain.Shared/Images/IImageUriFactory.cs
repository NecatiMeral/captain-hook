using System;
using System.Threading.Tasks;

namespace CaptainHook.Images
{
    public interface IImageUriFactory
    {
        Task<Uri> GetImageUriAsync(string providerKey, string imageId);
    }
}