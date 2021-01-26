// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Repository information.
    /// </summary>
    public class GitRepository
    {
        /// <summary>
        /// The Repository Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The Repository name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The Repository Url.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The project.
        /// </summary>
        [JsonPropertyName("project")]
        public GitProject Project { get; set; }

        /// <summary>
        /// The name of the default branch.
        /// </summary>
        [JsonPropertyName("defaultBranch")]
        public string DefaultBranch { get; set; }

        /// <summary>
        /// The remote Url.
        /// </summary>
        [JsonPropertyName("remoteUrl")]
        public Uri RemoteUrl { get; set; }
    }
}