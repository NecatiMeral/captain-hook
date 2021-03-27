using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Contains information about a comment on a pull request.
    /// </summary>
    public class GitPullRequestComment
    {
        /// <summary>
        /// The Comment Id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The parent comment Id which was replied to
        /// </summary>
        [JsonPropertyName("parentCommentId")]
        public int ParentCommentId { get; set; }

        /// <summary>
        /// The comment author
        /// </summary>
        [JsonPropertyName("author")]
        public GitUser Author { get; set; }

        /// <summary>
        /// The comment text
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("publishedDate")]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("lastUpdatedDate")]
        public DateTime LastUpdatedDate { get; set; }

        [JsonPropertyName("lastContentUpdatedDate")]
        public DateTime LastContentUpdatedDate { get; set; }

        [JsonPropertyName("commentType")]
        public string CommentType { get; set; }

        /// <summary>
        /// Pull Request comment Links
        /// </summary>
        [JsonPropertyName("_links")]
        public GitPullRequestCommentLinks Links { get; set; }
    }
}
