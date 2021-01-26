// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Links for the Pull Request
    /// </summary>
    public class GitPullLinks
    {
        /// <summary>
        /// Pull Request Link
        /// </summary>
        [JsonPropertyName("self")]
        public GitLink Self { get; set; }

        /// <summary>
        /// Link to pull request web view
        /// </summary>
        [JsonPropertyName("web")]
        public GitLink Web { get; set; }

        /// <summary>
        /// Repository Link
        /// </summary>
        [JsonPropertyName("repository")]
        public GitLink Repository { get; set; }

        /// <summary>
        /// Link to Work Items
        /// </summary>
        [JsonPropertyName("workItems")]
        public GitLink WorkItems { get; set; }

        /// <summary>
        /// Link to the Source Branch
        /// </summary>
        [JsonPropertyName("sourceBranch")]
        public GitLink SourceBranch { get; set; }

        /// <summary>
        /// Link to the Target Branch
        /// </summary>
        [JsonPropertyName("targetBranch")]
        public GitLink TargetBranch { get; set; }

        /// <summary>
        /// Link to the Source Commit
        /// </summary>
        [JsonPropertyName("sourceCommit")]
        public GitLink SourceCommit { get; set; }

        /// <summary>
        /// Link to the Target Commit
        /// </summary>
        [JsonPropertyName("targetCommit")]
        public GitLink TargetCommit { get; set; }

        /// <summary>
        /// Link to user that created the Commit
        /// </summary>
        [JsonPropertyName("createdBy")]
        public GitLink CreatedBy { get; set; }
    }
}