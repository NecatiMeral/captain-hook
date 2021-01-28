using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace CaptainHook.Receivers
{
    public class CaptainHookProcessingOptions
    {
        public List<CaptainHookReceiverItem> Receive { get; set; }

        public List<CaptainHookPublisherItem> Publish { get; set; }

        [NotNull]
        public Dictionary<string, Type> Handlers { get; }

        public CaptainHookProcessingOptions()
        {
            Receive = new List<CaptainHookReceiverItem>();
            Publish = new List<CaptainHookPublisherItem>();
            Handlers = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
