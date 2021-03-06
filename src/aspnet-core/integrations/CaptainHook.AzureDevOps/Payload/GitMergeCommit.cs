﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Merge Commit Information
    /// </summary>
    public class GitMergeCommit
    {
        /// <summary>
        /// Commit Id
        /// </summary>
        [JsonPropertyName("commitId")]
        public string CommitId { get; set; }

        /// <summary>
        /// Commit Url
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}