using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace CaptainHook.Receivers
{
    public class WebHookOptions
    {
        [NotNull]
        public Dictionary<string, Type> Handlers { get; }

        public WebHookOptions()
        {
            Handlers = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
