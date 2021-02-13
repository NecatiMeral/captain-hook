// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="GitPullRequestCreatedPayload"/>
    /// </summary>
    public class GitPullRequestResource : BaseResource
    {
        private readonly Collection<GitReviewer> _reviewers = new Collection<GitReviewer>();
        private readonly Collection<GitCommit> _commits = new Collection<GitCommit>();

        /// <summary>
        /// The repository being updated
        /// </summary>
        [JsonPropertyName("repository")]
        public GitRepository Repository { get; set; }

        /// <summary>
        /// The Id of the Pull Request
        /// </summary>
        [JsonPropertyName("pullRequestId")]
        public int PullRequestId { get; set; }

        /// <summary>
        /// The Status of the Pull Request
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The user creating the Pull Request
        /// </summary>
        [JsonPropertyName("createdBy")]
        public GitUser CreatedBy { get; set; }

        /// <summary>
        /// The date the Pull Request was created.
        /// </summary>
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The title of the Pull Request.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The Description of the Pull Request
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Source Reference Name
        /// </summary>
        [JsonPropertyName("sourceRefName")]
        public string SourceRefName { get; set; }

        /// <summary>
        /// Target Reference Name
        /// </summary>
        [JsonPropertyName("targetRefName")]
        public string TargetRefName { get; set; }

        /// <summary>
        /// Merge Status
        /// </summary>
        [JsonPropertyName("mergeStatus")]
        public string MergeStatus { get; set; }

        /// <summary>
        /// Merge Id
        /// </summary>
        [JsonPropertyName("mergeId")]
        public string MergeId { get; set; }

        /// <summary>
        /// Last Merge Source Commit
        /// </summary>
        [JsonPropertyName("lastMergeSourceCommit")]
        public GitMergeCommit LastMergeSourceCommit { get; set; }

        /// <summary>
        /// Last Merge Target Commit
        /// </summary>
        [JsonPropertyName("lastMergeTargetCommit")]
        public GitMergeCommit LastMergeTargetCommit { get; set; }

        /// <summary>
        /// Last Merge Commit
        /// </summary>
        [JsonPropertyName("lastMergeCommit")]
        public GitMergeCommit LastMergeCommit { get; set; }

        /// <summary>
        /// Pull Request Reviewers
        /// </summary>
        [JsonPropertyName("reviewers")]
        public GitReviewer[] Reviewers { get; set; }

        /// <summary>
        /// Pull Request Url
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Commit Links
        /// </summary>
        [JsonPropertyName("_links")]
        public GitPullLinks Links { get; set; }

        /// <summary>
        /// A list of commits in the pull request
        /// </summary>
        [JsonPropertyName("commits")]
        public Collection<GitCommit> Commits
        {
            get { return _commits; }
        }
    }
}