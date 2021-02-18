using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Client
{
    public class RocketChatInputDto
    {
        /// <summary>
        /// RocketChat server url.
        /// </summary>
        [JsonIgnore]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Username (required for authentication)
        /// </summary>
        [JsonIgnore]
        public string Username { get; set; }

        /// <summary>
        /// Password (required for authentication).
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; }
    }
}
