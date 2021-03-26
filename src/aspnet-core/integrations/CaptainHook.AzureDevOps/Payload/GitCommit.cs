// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Contains information about the commit.
    /// </summary>
    public class GitCommit
    {
        /// <summary>
        /// The Id of the commit.
        /// </summary>
        [JsonPropertyName("commitId")]
        public string CommitId { get; set; }

        /// <summary>
        /// The user that authorized the commit.
        /// </summary>
        [JsonPropertyName("author")]
        public GitUserInfo Author { get; set; }

        /// <summary>
        /// The user that committed the commit.
        /// </summary>
        [JsonPropertyName("committer")]
        public GitUserInfo Committer { get; set; }

        /// <summary>
        /// The commit comment.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// The url of the commit.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}