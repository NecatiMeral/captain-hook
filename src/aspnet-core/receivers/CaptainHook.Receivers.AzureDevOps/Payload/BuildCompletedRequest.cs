﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the request of the build.
    /// </summary>
    public class BuildCompletedRequest
    {
        /// <summary>
        /// Gets the identifier of the request.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the URL of the request.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets the user associated with the request.
        /// </summary>
        [JsonPropertyName("requestedFor")]
        public ResourceUser RequestedFor { get; set; }
    }
}
