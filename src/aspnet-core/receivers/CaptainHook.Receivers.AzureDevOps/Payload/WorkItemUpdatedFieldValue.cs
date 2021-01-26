// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes change of specific field
    /// </summary>
    /// <typeparam name="T">The string-type of the field that is being changed</typeparam>
    public class WorkItemUpdatedFieldValue<T>
    {
        /// <summary>
        /// Gets the value of the field before the change.
        /// </summary>
        [JsonPropertyName("oldValue")]
        public T OldValue { get; set; }

        /// <summary>
        /// Gets the value of the field after the change.
        /// </summary>
        [JsonPropertyName("newValue")]
        public T NewValue { get; set; }
    }
}
