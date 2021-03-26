// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes build definition
    /// </summary>
    public class BuildCompletedDefinition
    {
        /// <summary>
        /// Gets the size of the batch.
        /// </summary>
        [JsonPropertyName("batchSize")]
        public int BatchSize { get; set; }

        /// <summary>
        /// Gets the trigger type.
        /// </summary>
        [JsonPropertyName("triggerType")]
        public string TriggerType { get; set; }

        /// <summary>
        /// Gets the trigger type.
        /// </summary>
        [JsonPropertyName("definitionType")]
        public string DefinitionType { get; set; }

        /// <summary>
        /// Gets the identifier of the build definition.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the build definition.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the URL of the build definition.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}
