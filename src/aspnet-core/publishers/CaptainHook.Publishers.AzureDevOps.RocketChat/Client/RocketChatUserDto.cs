using System.Text.Json.Serialization;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class RocketChatUserDto
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("emails")]
        public RocketChatUserEmail[] Emails { get; set; }
    }

    public class RocketChatUserEmail
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }
    }
}
