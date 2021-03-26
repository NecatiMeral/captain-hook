// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Root object of payload sent for all types of events.
    /// </summary>
    /// <typeparam name="T">Type of resource within payload which differs depending on '<c>eventType</c>' field</typeparam>
    public abstract class BasePayload<T> : EventPayload
        where T : BaseResource
    {
        /// <summary>
        /// Gets the subscription identifier which triggered the event.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets the notification identifier within subscription.
        /// </summary>
        [JsonPropertyName("notificationId")]
        public int NotificationId { get; set; }

        /// <summary>
        /// Gets the identifier of HTTP request.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets the publisher identifier.
        /// </summary>
        [JsonPropertyName("publisherId")]
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets the message which describes the event.
        /// </summary>
        [JsonPropertyName("message")]
        public PayloadMessage Message { get; set; }

        /// <summary>
        /// Gets the detailed message which describes the event.
        /// </summary>
        [JsonPropertyName("detailedMessage")]
        public PayloadMessage DetailedMessage { get; set; }

        /// <summary>
        /// Gets the resource itself - data associated with corresponding event.
        /// </summary>
        [JsonPropertyName("resource")]
        public T Resource { get; set; }

        /// <summary>
        /// Gets the resource version.
        /// </summary>
        [JsonPropertyName("resourceVersion")]
        public string ResourceVersion { get; set; }

        /// <summary>
        /// Gets the resource containers.
        /// </summary>
        [JsonPropertyName("resourceContainers")]
        public PayloadResourceContainers ResourceContainers { get; set; }

        /// <summary>
        /// Gets the date when HTTP request was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
