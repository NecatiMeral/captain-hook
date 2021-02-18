// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes fields of the WorkItem
    /// </summary>
    public class WorkItemFields
    {
        /// <summary>
        /// Gets the value of field <c>System.AreaPath</c>.
        /// </summary>
        [JsonPropertyName("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.TeamProject</c>.
        /// </summary>
        [JsonPropertyName("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.IterationPath</c>.
        /// </summary>
        [JsonPropertyName("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.WorkItemType</c>.
        /// </summary>
        [JsonPropertyName("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.State</c>.
        /// </summary>
        [JsonPropertyName("System.State")]
        public string SystemState { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.Reason</c>.
        /// </summary>
        [JsonPropertyName("System.Reason")]
        public string SystemReason { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.AssignedTo</c>.
        /// </summary>
        [JsonPropertyName("System.AssignedTo")]
        public string SystemAssignedTo { get; set; }
        
        /// <summary>
        /// Gets the value of field <c>System.CreatedDate</c>.
        /// </summary>
        [JsonPropertyName("System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.CreatedBy</c>.
        /// </summary>
        [JsonPropertyName("System.CreatedBy")]
        public string SystemCreatedBy { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.ChangedDate</c>.
        /// </summary>
        [JsonPropertyName("System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.ChangedBy</c>.
        /// </summary>
        [JsonPropertyName("System.ChangedBy")]
        public string SystemChangedBy { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.Title</c>.
        /// </summary>
        [JsonPropertyName("System.Title")]
        public string SystemTitle { get; set; }

        /// <summary>
        /// Gets the value of field <c>Microsoft.VSTS.Common.Severity</c>.
        /// </summary>
        [JsonPropertyName("Microsoft.VSTS.Common.Severity")]
        public string MicrosoftCommonSeverity { get; set; }

        /// <summary>
        /// Gets the value of field <c>WEF_EB329F44FE5F4A94ACB1DA153FDF38BA_Kanban.Column</c>.
        /// </summary>
        [JsonPropertyName("WEF_EB329F44FE5F4A94ACB1DA153FDF38BA_Kanban.Column")]
        public string KanbanColumn { get; set; }

        /// <summary>
        /// Gets the value of field <c>System.History</c>.
        /// </summary>
        [JsonPropertyName("System.History")]
        public string SystemHistory { get; set; }
    }
}
