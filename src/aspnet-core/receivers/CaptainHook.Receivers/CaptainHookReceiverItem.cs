using System;

namespace CaptainHook.Receivers
{
    public class CaptainHookReceiverItem
    {
        public string HandlerName { get; set; }
        public string Identifier { get; set; }

        public bool Equals(string handlerName, string identifier)
            => string.Equals(HandlerName, handlerName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(Identifier, identifier, StringComparison.OrdinalIgnoreCase);
    }
}
