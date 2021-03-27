using Microsoft.VisualStudio.Services.Profile;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Client
{
    public class CaptainHookAzureDevOpsAvatar
    {
        [JsonPropertyName("imageData")]
        public byte[] ImageData { get; set; }
        [JsonPropertyName("imageType")]
        public string ImageType { get; set; }
        [JsonPropertyName("size")]
        public AvatarSize Size { get; }
    }
}