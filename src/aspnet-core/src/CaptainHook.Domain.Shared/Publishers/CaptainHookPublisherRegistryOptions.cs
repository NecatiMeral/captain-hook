using System.Collections.Generic;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherRegistryOptions
    {
        public CaptainHookPublisherRegistry PublisherHandlers { get; set; }

        public CaptainHookPublisherRegistryOptions()
        {
            PublisherHandlers = new CaptainHookPublisherRegistry();
        }
    }
}
