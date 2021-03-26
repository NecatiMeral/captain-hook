using System.Text.Json.Serialization;

namespace CaptainHook.RocketChat
{
    public class MessageDto
    {
        /// <summary>
        /// The channel name with the prefix in front of it.  
        /// # refers to channel, however @ refers to username
        /// </summary>
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// The text of the message to send, is optional because of attachments.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// This will cause the message's name to appear as the given alias, but your username will still display.
        /// </summary>
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// If provided, this will make the avatar on this message be an emoji. <see href="http://emoji.codes/">Emoji Cheetsheet</see>
        /// </summary>
        [JsonPropertyName("emoji")]
        public string Emoji { get; set; }

        /// <summary>
        /// If provided, this will make the avatar use the provided image url.
        /// </summary>
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// An array of <see cref="MessageAttachmentDto"/>
        /// </summary>
        [JsonPropertyName("attachments")]
        public MessageAttachmentDto[] Attachments { get; set; }
    }
}
