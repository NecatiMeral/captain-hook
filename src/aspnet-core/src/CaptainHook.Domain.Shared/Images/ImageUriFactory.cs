using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Images
{
    public class ImageUriFactory : IImageUriFactory, ITransientDependency
    {
        protected string SelfUrl { get; }

        public ImageUriFactory(IConfiguration configuration)
        {
            SelfUrl = configuration["App:SelfUrl"];
        }

        public Task<Uri> GetImageUriAsync(string providerKey, string imageId)
        {
            var builder = new UriBuilder(SelfUrl);
            builder.Path = $"api/images/show/{providerKey}/{HttpUtility.UrlEncode(imageId)}";

            return Task.FromResult(builder.Uri);
        }
    }
}
