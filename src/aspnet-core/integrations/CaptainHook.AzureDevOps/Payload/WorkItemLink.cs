// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the WorkItem's link.
    /// </summary>
    public class WorkItemLink : IAzureLink
    {
        /// <summary>
        /// Gets the URL of WorkItem's link.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
