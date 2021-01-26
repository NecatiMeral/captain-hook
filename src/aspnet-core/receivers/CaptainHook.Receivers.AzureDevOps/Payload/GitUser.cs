// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Information about the git user.
    /// </summary>
    public class GitUser
    {
        /// <summary>
        /// The git user Id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The git user display name.
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The git user unique name.
        /// </summary>
        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }

        /// <summary>
        /// The git user url.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The git user's image url.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public Uri ImageUrl { get; set; }
    }
}