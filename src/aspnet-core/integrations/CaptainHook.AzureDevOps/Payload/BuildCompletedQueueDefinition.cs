// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the queue of the build.
    /// </summary>
    public class BuildCompletedQueueDefinition
    {
        /// <summary>
        /// Gets the type of the queue.
        /// </summary>
        [JsonPropertyName("queueType")]
        public string QueueType { get; set; }

        /// <summary>
        /// Gets the identifier of the queue.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the URL of the queue.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}