// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the resource that associated with <see cref="TeamRoomMessagePostedPayload"/>
    /// </summary>
    public class TeamRoomMessagePostedResource : BaseResource
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        [JsonPropertyName("messageType")]
        public string MessageType { get; set; }

        /// <summary>
        /// Gets the posted time of the message.
        /// </summary>
        [JsonPropertyName("postedTime")]
        public DateTime PostedTime { get; set; }

        /// <summary>
        /// Gets the room identifier where message was posted.
        /// </summary>
        [JsonPropertyName("postedRoomId")]
        public int PostedRoomId { get; set; }

        /// <summary>
        /// Gets the user who posted the message.
        /// </summary>
        [JsonPropertyName("postedBy")]
        public ResourceUser PostedBy { get; set; }
    }
}
