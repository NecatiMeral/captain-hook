using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes links of the pipeline.
    /// </summary>
    public class PipelineLinks
    {
        /// <summary>
        /// Gets the link to the current pipeline run.
        /// </summary>
        [JsonPropertyName("self")]
        public PipelineLink Self { get; set; }

        /// <summary>
        /// Gets the link to the pipeline results.
        /// </summary>
        [JsonPropertyName("web")]
        public PipelineLink Web { get; set; }

        /// <summary>
        /// Gets the link to the pipeline definition.
        /// </summary>
        [JsonPropertyName("pipeline.web")]
        public PipelineLink PipeLineWeb { get; set; }

        /// <summary>
        /// Gets the link to the pipeline revision.
        /// </summary>
        [JsonPropertyName("pipeline")]
        public PipelineLink Pipeline { get; set; }
    }
}
