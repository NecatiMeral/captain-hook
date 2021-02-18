// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    /// <summary>
    /// Describes payload message.
    /// </summary>
    public class PayloadMessage
    {
        /// <summary>
        /// Gets the message in plain text.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets the message in HTML format.
        /// </summary>
        [JsonPropertyName("html")]
        public string Html { get; set; }

        /// <summary>
        /// Gets the message in markdown format.
        /// </summary>
        [JsonPropertyName("markdown")]
        public string Markdown { get; set; }
    }
}
