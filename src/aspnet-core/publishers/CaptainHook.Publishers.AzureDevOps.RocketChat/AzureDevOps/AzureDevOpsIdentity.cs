using System;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public class AzureDevOpsIdentity
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
    }
}
