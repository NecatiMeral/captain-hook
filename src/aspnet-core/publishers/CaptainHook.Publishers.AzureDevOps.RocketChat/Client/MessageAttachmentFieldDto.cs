using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class MessageAttachmentFieldDto
    {
        /// <summary>
        /// Whether this field should be a short field.
        /// </summary>
        [JsonPropertyName("short")]
        [DefaultValue(false)]
        public bool Short { get; set; }

        /// <summary>
        /// The title of this field.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The value of this field, displayed underneath the title value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
