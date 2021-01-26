// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="BuildCompletedPayload"/>
    /// </summary>
    public class BuildCompletedResource : BaseResource
    {
        private readonly Collection<BuildCompletedRequest> _requests = new Collection<BuildCompletedRequest>();

        /// <summary>
        /// Gets the build URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets the build identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the build number.
        /// </summary>
        [JsonPropertyName("buildNumber")]
        public string BuildNumber { get; set; }

        /// <summary>
        /// Gets the build URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets the start time of the build.
        /// </summary>
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets the finish time of the build.
        /// </summary>
        [JsonPropertyName("finishTime")]
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// Gets the reason which triggered the build.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets the outcome status of the build.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets the build drop location.
        /// </summary>
        [JsonPropertyName("dropLocation")]
        public string DropLocation { get; set; }

        /// <summary>
        /// Gets the build drop.
        /// </summary>
        [JsonPropertyName("drop")]
        public BuildCompletedDrop Drop { get; set; }

        /// <summary>
        /// Gets the build log.
        /// </summary>
        [JsonPropertyName("log")]
        public BuildCompletedLog Log { get; set; }

        /// <summary>
        /// Gets the source version for the build.
        /// </summary>
        [JsonPropertyName("sourceGetVersion")]
        public string SourceGetVersion { get; set; }

        /// <summary>
        /// Gets the user which last changed the source.
        /// </summary>
        [JsonPropertyName("lastChangedBy")]
        public ResourceUser LastChangedBy { get; set; }

        /// <summary>
        /// Gets value indicating whether this build retain indefinitely.
        /// </summary>
        [JsonPropertyName("retainIndefinitely")]
        public bool RetainIndefinitely { get; set; }

        /// <summary>
        /// Gets value indicating whether this build has diagnostics.
        /// </summary>
        [JsonPropertyName("hasDiagnostics")]
        public bool HasDiagnostics { get; set; }

        /// <summary>
        /// Gets the definition of the build.
        /// </summary>
        [JsonPropertyName("definition")]
        public BuildCompletedDefinition Definition { get; set; }

        /// <summary>
        /// Gets the build queue.
        /// </summary>
        [JsonPropertyName("queue")]
        public BuildCompletedQueueDefinition Queue { get; set; }

        /// <summary>
        /// Gets build requests.
        /// </summary>
        [JsonPropertyName("requests")]
        public Collection<BuildCompletedRequest> Requests
        {
            get { return _requests; }
        }
    }
}
