// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes links of the WorkItem.
    /// </summary>
    public class WorkItemLinks
    {
        /// <summary>
        /// Gets the link to the WorkItem itself.
        /// </summary>
        [JsonPropertyName("self")]
        public WorkItemLink Self { get; set; }

        /// <summary>
        /// Gets the link to the parent WorkItem if exists.
        /// </summary>
        [JsonPropertyName("parent")]
        public WorkItemLink Parent { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem' updates.
        /// </summary>
        [JsonPropertyName("workItemUpdates")]
        public WorkItemLink WorkItemUpdates { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem's revisions.
        /// </summary>
        [JsonPropertyName("workItemRevisions")]
        public WorkItemLink WorkItemRevisions { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem's type.
        /// </summary>
        [JsonPropertyName("workItemType")]
        public WorkItemLink WorkItemType { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem's fields.
        /// </summary>
        [JsonPropertyName("fields")]
        public WorkItemLink Fields { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem's HTML.
        /// </summary>
        [JsonPropertyName("html")]
        public WorkItemLink Html { get; set; }

        /// <summary>
        /// Gets the link to the WorkItem's history.
        /// </summary>
        [JsonPropertyName("workItemHistory")]
        public WorkItemLink WorkItemHistory { get; set; }
    }
}
