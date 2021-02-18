// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes build log 
    /// </summary>
    public class BuildCompletedLog
    {
        /// <summary>
        /// Gets the log type.
        /// </summary>
        [JsonPropertyName("type")]
        public string LogType { get; set; }

        /// <summary>
        /// Gets the log URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets the log download URL.
        /// </summary>
        [JsonPropertyName("downloadUrl")]
        public Uri DownloadUrl { get; set; }
    }
}
