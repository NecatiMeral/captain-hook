// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes build drop
    /// </summary>
    public class BuildCompletedDrop
    {
        /// <summary>
        /// Gets drop location.
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets drop type.
        /// </summary>
        [JsonPropertyName("type")]
        public string DropType { get; set; }

        /// <summary>
        /// Gets drop location URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets drop location download URL.
        /// </summary>
        [JsonPropertyName("downloadUrl")]
        public Uri DownloadUrl { get; set; }
    }
}
