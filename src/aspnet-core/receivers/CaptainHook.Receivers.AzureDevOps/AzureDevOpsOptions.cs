using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainHook.Receivers.AzureDevOps
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
