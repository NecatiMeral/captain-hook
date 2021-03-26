// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="GitPushPayload"/>
    /// </summary>
    public class GitPushResource : BaseResource
    {
        private readonly Collection<GitCommit> _commits = new Collection<GitCommit>();
        private readonly Collection<GitRefUpdate> _refUpdates = new Collection<GitRefUpdate>();

        /// <summary>
        /// List of Commits in the push.
        /// </summary>
        [JsonPropertyName("commits")]
        public Collection<GitCommit> Commits
        {
            get { return _commits; }
        }

        /// <summary>
        /// List of Reference updates.
        /// </summary>
        [JsonPropertyName("refUpdates")]
        public Collection<GitRefUpdate> RefUpdates
        {
            get { return _refUpdates; }
        }

        /// <summary>
        /// The repository being updated
        /// </summary>
        [JsonPropertyName("repository")]
        public GitRepository Repository { get; set; }

        /// <summary>
        /// The user pushing the code.
        /// </summary>
        [JsonPropertyName("pushedBy")]
        public GitUser PushedBy { get; set; }

        /// <summary>
        /// The Id of the push.
        /// </summary>
        [JsonPropertyName("pushId")]
        public int PushId { get; set; }

        /// <summary>
        /// The date of the push.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The Url of the push.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Links for the push
        /// </summary>
        [JsonPropertyName("_links")]
        public GitPushLinks Links { get; set; }
    }
}