// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// A collection of links about this push.
    /// </summary>
    public class GitPushLinks
    {
        /// <summary>
        /// The link to the push.
        /// </summary>
        [JsonPropertyName("self")]
        public GitLink Self { get; set; }

        /// <summary>
        /// The link to the repository.
        /// </summary>
        [JsonPropertyName("repository")]
        public GitLink Repository { get; set; }

        /// <summary>
        /// The link to the commits.
        /// </summary>
        [JsonPropertyName("commits")]
        public GitLink Commits { get; set; }

        /// <summary>
        /// The link to the user pushing the code.
        /// </summary>
        [JsonPropertyName("pusher")]
        public GitLink Pusher { get; set; }

        /// <summary>
        /// The link to any references.
        /// </summary>
        [JsonPropertyName("refs")]
        public GitLink Refs { get; set; }
    }
}