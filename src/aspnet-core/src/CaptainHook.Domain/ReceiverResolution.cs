using CaptainHook.Receivers;
using System;

namespace CaptainHook
{
    public class ReceiverResolution
    {
        public Type Handler { get; }

        public CaptainHookReceiverItem Receiver { get; }

        public ReceiverResolution(Type handler, CaptainHookReceiverItem receiver)
        {
            Handler = handler;
            Receiver = receiver;
        }
    }
}
