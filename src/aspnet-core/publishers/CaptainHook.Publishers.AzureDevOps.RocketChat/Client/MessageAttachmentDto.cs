using System.Text.Json.Serialization;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class MessageAttachmentDto
    {
        /// <summary>
        /// The color you want the order on the left side to be, any value background-css supports.
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// The text to display for this attachment, it is different than the message's text.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Displays the time next to the text portion.
        /// </summary>
        [JsonPropertyName("ts")]
        public string Timestamp { get; set; }

        /// <summary>
        /// An image that displays to the left of the text, looks better when this is relatively small.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Only applicable if the ts is provided, as it makes the time clickable to this link.
        /// </summary>
        [JsonPropertyName("message_link")]
        public string MessageLink { get; set; }

        /// <summary>
        /// Causes the image, audio, and video sections to be hiding when collapsed is true.
        /// </summary>
        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }

        /// <summary>
        /// Name of the author.
        /// </summary>
        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Providing this makes the author name clickable and points to this link.
        /// </summary>
        [JsonPropertyName("author_link")]
        public string AuthorLink { get; set; }

        /// <summary>
        /// Displays a tiny icon to the left of the Author's name.
        /// </summary>
        [JsonPropertyName("author_icon")]
        public string AuthorIcon { get; set; }

        /// <summary>
        /// Title to display for this attachment, displays under the author.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Providing this makes the title clickable, pointing to this link.
        /// </summary>
        [JsonPropertyName("title_link")]
        public string TitleLink { get; set; }

        /// <summary>
        /// When this is true, a download icon appears and clicking this saves the link to file.
        /// </summary>
        [JsonPropertyName("title_link_download")]
        public bool TitleLinkDownload { get; set; }

        /// <summary>
        /// The image to display, will be "big" and easy to see.
        /// </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// An array of <see cref="MessageAttachmentFieldDto"/>
        /// </summary>
        [JsonPropertyName("fields")]
        public MessageAttachmentFieldDto[] Fields { get; set; }
    }
}
