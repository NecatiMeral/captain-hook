// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes fields of the WorkItem that was updated
    /// </summary>
    public class WorkItemUpdatedFields
    {
        /// <summary>
        /// Gets the change information for the field '<c>System.Rev</c>'.
        /// </summary>
        [JsonPropertyName("System.Rev")]
        public WorkItemUpdatedFieldValue<string> SystemRev { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.AuthorizedDate</c>'.
        /// </summary>
        [JsonPropertyName("System.AuthorizedDate")]
        public WorkItemUpdatedFieldValue<DateTime> SystemAuthorizedDate { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.RevisedDate</c>'.
        /// </summary>
        [JsonPropertyName("System.RevisedDate")]
        public WorkItemUpdatedFieldValue<DateTime> SystemRevisedDate { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.State</c>'.
        /// </summary>
        [JsonPropertyName("System.State")]
        public WorkItemUpdatedFieldValue<string> SystemState { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.Reason</c>'.
        /// </summary>
        [JsonPropertyName("System.Reason")]
        public WorkItemUpdatedFieldValue<string> SystemReason { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.AssignedTo</c>'.
        /// </summary>
        [JsonPropertyName("System.AssignedTo")]
        public WorkItemUpdatedFieldValue<string> SystemAssignedTo { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.ChangedDate</c>'.
        /// </summary>
        [JsonPropertyName("System.ChangedDate")]
        public WorkItemUpdatedFieldValue<DateTime> SystemChangedDate { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>System.Watermark</c>'.
        /// </summary>
        [JsonPropertyName("System.Watermark")]
        public WorkItemUpdatedFieldValue<string> SystemWatermark { get; set; }

        /// <summary>
        /// Gets the change information for the field '<c>Microsoft.VSTS.Common.Severity</c>'.
        /// </summary>
        [JsonPropertyName("Microsoft.Vsts.Common.Severity")]
        public WorkItemUpdatedFieldValue<string> MicrosoftCommonSeverity { get; set; }
    }    
}
