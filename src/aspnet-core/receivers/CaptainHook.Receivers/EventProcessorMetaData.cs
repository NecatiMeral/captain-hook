using System;

namespace CaptainHook.Receivers
{
    public class EventProcessorMetaData
    {
        public string ReceiverName { get; set; }

        public string EventType { get; set; }

        public string Id { get; set; }

        public Type Handler { get; set; }
    }
}
