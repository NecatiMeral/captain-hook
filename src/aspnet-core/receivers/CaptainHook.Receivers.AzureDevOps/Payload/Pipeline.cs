using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the pipeline entity
    /// </summary>
    public class Pipeline
    {
        /// <summary>
        /// Gets the id of the pipeline.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the pipeline URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The Pipeline name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The Pipeline folder.
        /// </summary>
        [JsonPropertyName("folder")]
        public string Folder { get; set; }

        /// <summary>
        /// The Revision.
        /// </summary>
        [JsonPropertyName("revision")]
        public int Revision { get; set; }
    }
}
