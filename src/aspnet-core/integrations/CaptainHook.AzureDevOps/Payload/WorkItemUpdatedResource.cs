// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="WorkItemUpdatedPayload"/>
    /// </summary>
    public class WorkItemUpdatedResource : BaseWorkItemResource<WorkItemUpdatedFields>
    {
        /// <summary>
        /// Gets WorkItem identifier.
        /// </summary>
        [JsonPropertyName("workItemId")]
        public int WorkItemId { get; set; }

        /// <summary>
        /// Gets the author of revision.
        /// </summary>
        [JsonPropertyName("revisedBy")]
        public ResourceUser RevisedBy { get; set; }

        /// <summary>
        /// Gets the revised date.
        /// </summary>
        [JsonPropertyName("revisedDate")]
        public DateTime RevisedDate { get; set; }

        /// <summary>
        /// Gets the revision.
        /// </summary>
        [JsonPropertyName("revision")]
        public WorkItemUpdatedRevision Revision { get; set; }
    }    
}
