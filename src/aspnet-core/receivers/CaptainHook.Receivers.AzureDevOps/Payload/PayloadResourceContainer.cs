// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes container
    /// </summary>
    public class PayloadResourceContainer
    {
        /// <summary>
        /// Gets the identifier of container.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
