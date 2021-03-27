using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Links for the Pull Request comment
    /// </summary>
    public class GitPullRequestCommentLinks
    {
        /// <summary>
        /// Comment Link
        /// </summary>
        [JsonPropertyName("self")]
        public GitLink Self { get; set; }

        /// <summary>
        /// Repository Link
        /// </summary>
        [JsonPropertyName("repository")]
        public GitLink Repository { get; set; }

        /// <summary>
        /// Threads Link
        /// </summary>
        [JsonPropertyName("threads")]
        public GitLink Threads { get; set; }

        /// <summary>
        /// Pull Requests Link
        /// </summary>
        [JsonPropertyName("pullRequests")]
        public GitLink PullRequests { get; set; }
    }
}
