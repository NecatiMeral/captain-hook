using CaptainHook.Images;
using FileSignatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace CaptainHook
{
    public class ImageAppService : CaptainHookAppService, IImageAppService
    {
        protected IEnumerable<IImageProvider> ImageProviders { get; }
        protected IDistributedCache<ImageDto> ImageCache { get; }
        protected IFileFormatInspector FileFormatInspector { get; }

        public ImageAppService(
            IEnumerable<IImageProvider> imageContributors,
            IDistributedCache<ImageDto> imageCache,
            IFileFormatInspector fileFormatInspector)
        {
            ImageProviders = imageContributors;
            ImageCache = imageCache;
            FileFormatInspector = fileFormatInspector;
        }

        public async Task<ImageDto> GetImageAsync(string providerName, string imageId)
        {
            var key = ImageDto.CalculateCacheKey(providerName, imageId);

            return await ImageCache.GetOrAddAsync(
                key,
                () => GetImageFromProvidersAsync(providerName, imageId)
            );
        }

        private async Task<ImageDto> GetImageFromProvidersAsync(string providerName, string imageId)
        {
            foreach (var provider in ImageProviders)
            {
                if (await provider.IsSatisfiedByAsync(providerName))
                {
                    var result = await provider.GetImageAsync(imageId);
                    if (result != null)
                    {
                        EnsureMediaTypeIsSet(result);
                        return result;
                    }
                }
            }
            return null;
        }

        void EnsureMediaTypeIsSet(ImageDto image)
        {
            if (image.MediaType.IsNullOrWhiteSpace())
            {
                using (var memStream = new MemoryStream(image.Payload, false))
                {
                    var format = FileFormatInspector.DetermineFileFormat(memStream);
                    if (format != null)
                    {
                        image.MediaType = format.MediaType;
                    }
                }
            }
        }
    }
}
