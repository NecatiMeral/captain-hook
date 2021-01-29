using System.Collections.Generic;

namespace CaptainHook.Receivers
{
    public class CaptainHookReceiverOptions
    {
        public List<CaptainHookReceiverItem> Receive { get; set; }

        public CaptainHookReceiverOptions()
        {
            Receive = new List<CaptainHookReceiverItem>();
        }
    }
}
