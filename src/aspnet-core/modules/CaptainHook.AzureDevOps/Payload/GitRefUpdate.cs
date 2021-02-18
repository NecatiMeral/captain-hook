// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Information about the references.
    /// </summary>
    public class GitRefUpdate
    {
        /// <summary>
        /// The name of the reference.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The old object Id.
        /// </summary>
        [JsonPropertyName("oldObjectId")]
        public string OldObjectId { get; set; }

        /// <summary>
        /// The new object Id.
        /// </summary>
        [JsonPropertyName("newObjectId")]
        public string NewObjectId { get; set; }
    }
}