using System;
using System.Collections.Generic;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public class AzureDevOpsIdentityDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsContainer { get; set; }
        //public string ImageUri { get; set; }
        public Guid[] MemberIds { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
