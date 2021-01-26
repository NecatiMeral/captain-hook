// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Information on a reviewer of a Pull Request.  Extends <see cref="GitUser"/>
    /// </summary>
    public class GitReviewer : GitUser
    {
        /// <summary>
        /// Url of reviewer.
        /// </summary>
        [JsonPropertyName("reviewerUrl")]
        public Uri ReviewerUrl { get; set; }

        /// <summary>
        /// The Reviewer's Vote
        /// </summary>
        [JsonPropertyName("vote")]
        public int Vote { get; set; }

        /// <summary>
        /// Is Container
        /// </summary>
        [JsonPropertyName("isContainer")]
        public bool IsContainer { get; set; }
    }
}