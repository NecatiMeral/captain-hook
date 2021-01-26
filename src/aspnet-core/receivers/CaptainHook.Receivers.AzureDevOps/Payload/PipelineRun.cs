using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the current run of the pipeline.
    /// </summary>
    public class PipelineRun
    {
        /// <summary>
        /// Links for the run.
        /// </summary>
        [JsonPropertyName("_links")]
        public PipelineLinks Links { get; set; }

        /// <summary>
        /// The associated pipeline.
        /// </summary>
        [JsonPropertyName("pipeline")]
        public Pipeline Pipeline { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("finishedDate")]
        public DateTime? FinishedDate { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
