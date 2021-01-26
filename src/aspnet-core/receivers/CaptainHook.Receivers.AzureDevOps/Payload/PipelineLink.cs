using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the pipeline's link.
    /// </summary>
    public class PipelineLink : IAzureLink
    {
        /// <summary>
        /// Gets the URL of pipeline's link.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
