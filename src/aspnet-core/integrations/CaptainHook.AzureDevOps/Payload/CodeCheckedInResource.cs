// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="CodeCheckedInPayload"/>
    /// </summary>
    public class CodeCheckedInResource : BaseResource
    {
        /// <summary>
        /// Gets the changeset identifier.
        /// </summary>
        [JsonPropertyName("changesetId")]
        public int ChangesetId { get; set; }

        /// <summary>
        /// Gets the changeset URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets the changeset author.
        /// </summary>
        [JsonPropertyName("author")]
        public ResourceUser Author { get; set; }

        /// <summary>
        /// Gets the user that checked in the changeset.
        /// </summary>
        [JsonPropertyName("checkedInBy")]
        public ResourceUser CheckedInBy { get; set; }

        /// <summary>
        /// Gets the changeset creation date.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets the changeset comment.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
