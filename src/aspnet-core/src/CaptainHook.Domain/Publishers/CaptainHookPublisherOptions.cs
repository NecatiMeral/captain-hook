using System.Collections.Generic;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherOptions
    {
        public List<CaptainHookPublisherItem> Publish { get; set; }

        public bool EnablePublishing { get; set; }

        public CaptainHookPublisherOptions()
        {
            Publish = new List<CaptainHookPublisherItem>();
        }
    }
}
