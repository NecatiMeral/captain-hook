using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace CaptainHook.Receivers
{
    public class CaptainHookReceiverHandlerOptions
    {
        [NotNull]
        public Dictionary<string, Type> Handlers { get; }

        public CaptainHookReceiverHandlerOptions()
        {
            Handlers = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
