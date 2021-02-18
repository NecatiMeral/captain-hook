using CaptainHook.Images;
using System;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.DependencyInjection;
using CaptainHook.AzureDevOps.Client;

namespace CaptainHook.AzureDevOps.Images
{
    public class IdentityImageProvider : IImageProvider, ITransientDependency
    {
        protected IAzureDevOpsService AzureDevOpsService { get; }

        public IdentityImageProvider(IAzureDevOpsService azureDevOpsService)
        {
            AzureDevOpsService = azureDevOpsService;
        }

        public Task<bool> IsSatisfiedByAsync(string providerKey)
        {
            return Task.FromResult(
                !providerKey.IsNullOrWhiteSpace()
                    && string.Equals(providerKey, AzureDevOpsConstants.ReceiverName, StringComparison.Ordinal)
            );
        }

        public async Task<ImageDto> GetImageAsync(string imageId)
        {
            imageId = HttpUtility.UrlDecode(imageId);
            var segments = imageId.Split('|');
            if (segments.Length == 2)
            {
                var decodedUri = segments[0].EnsureEndsWith('/');
                var collectionUrl = new Uri(decodedUri);
                var identifier = Guid.Parse(segments[1]);

                var image = await AzureDevOpsService.DownloadIdentityImageAsync(collectionUrl, identifier);
                if (image != null)
                {
                    return new ImageDto
                    {
                        Payload = image.Payload,
                        MediaType = image.MediaType
                    };
                }
            }
            return null;
        }

        public static string GetImageId(Uri imageUri)
        {
            var uri = new UriBuilder(imageUri.Scheme, imageUri.Host);

            if (imageUri.Segments.Length >= 2)
            {
                uri.Path = imageUri.Segments[1];
            }

            string imageId = HttpUtility.ParseQueryString(imageUri.Query).Get("id");
            return $"{uri.Uri.AbsoluteUri}|{imageId}";
        }
    }
}
