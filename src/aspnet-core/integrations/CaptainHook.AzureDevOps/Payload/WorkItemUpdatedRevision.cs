// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the revision
    /// </summary>
    public class WorkItemUpdatedRevision
    {
        /// <summary>
        /// Gets the identifier of the revision.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the revision number.
        /// </summary>
        [JsonPropertyName("rev")]
        public int Rev { get; set; }

        /// <summary>
        /// Gets the revision fields.
        /// </summary>
        [JsonPropertyName("fields")]
        public WorkItemFields Fields { get; set; }

        /// <summary>
        /// Gets the revision URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}
