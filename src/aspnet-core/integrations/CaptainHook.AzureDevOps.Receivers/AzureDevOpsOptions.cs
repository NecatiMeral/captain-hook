using System;
using System.Collections.Generic;

namespace CaptainHook.AzureDevOps.Receiver
{
    class AzureDevOpsOptions
    {
        public Dictionary<string, Type> Handlers { get; }

        public AzureDevOpsOptions()
        {
            Handlers = new Dictionary<string, Type>();
        }
    }
}
