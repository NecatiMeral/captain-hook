// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes containers containing the resource
    /// </summary>
    public class PayloadResourceContainers
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        [JsonPropertyName("collection")]
        public PayloadResourceContainer Collection { get; set; }

        /// <summary>
        /// Gets the account.
        /// </summary>
        [JsonPropertyName("account")]
        public PayloadResourceContainer Account { get; set; }

        /// <summary>
        /// Gets the project.
        /// </summary>
        [JsonPropertyName("project")]
        public PayloadResourceContainer Project { get; set; }
    }
}
