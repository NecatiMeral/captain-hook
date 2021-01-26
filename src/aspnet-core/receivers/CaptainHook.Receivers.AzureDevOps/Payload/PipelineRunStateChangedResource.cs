using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="PipelineRunStateChangedPayload"/>
    /// </summary>
    public class PipelineRunStateChangedResource : BaseResource
    {
        /// <summary>
        /// The current pipeline run.
        /// </summary>
        [JsonPropertyName("run")]
        public PipelineRun Run { get; set; }

        /// <summary>
        /// The pipeline.
        /// </summary>
        [JsonPropertyName("pipeline")]
        public Pipeline Pipeline { get; set; }
    }
}
