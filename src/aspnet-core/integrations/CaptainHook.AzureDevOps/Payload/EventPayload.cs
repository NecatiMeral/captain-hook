using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.Payload
{
    public class EventPayload
    {
        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        [JsonPropertyName("eventType")]
        public string EventType { get; set; }
    }
}
