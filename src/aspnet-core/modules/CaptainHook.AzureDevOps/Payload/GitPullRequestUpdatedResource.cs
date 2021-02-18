// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="GitPullRequestUpdatedPayload"/>
    /// </summary>
    public class GitPullRequestUpdatedResource : GitPullRequestResource
    {
        /// <summary>
        /// The date the Pull Request was closed.
        /// </summary>
        [JsonPropertyName("closedDate")]
        public DateTime ClosedDate { get; set; }
    }
}