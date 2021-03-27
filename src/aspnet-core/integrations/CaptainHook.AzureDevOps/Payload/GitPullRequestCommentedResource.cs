using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="GitPullRequestMergeCommitCreatedPayload"/>
    /// </summary>
    public class GitPullRequestCommentedResource : BaseResource
    {
        /// <summary>
        /// The Comment
        /// </summary>
        [JsonPropertyName("comment")]
        public GitPullRequestComment Comment { get; set; }

        /// <summary>
        /// The Pull request
        /// </summary>
        [JsonPropertyName("pullRequest")]
        public GitPullRequestResource PullRequest { get; set; }
    }
}