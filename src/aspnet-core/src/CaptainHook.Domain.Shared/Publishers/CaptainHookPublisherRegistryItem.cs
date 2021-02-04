using System;
using System.Collections.Generic;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherRegistry
    {
        List<CaptainHookPublisherRegistryItem> InnerList;

        public CaptainHookPublisherRegistry()
        {
            InnerList = new List<CaptainHookPublisherRegistryItem>();
        }

        public CaptainHookPublisherRegistryItem GetOrAdd(string receiverName, string publisherName)
        {
            var item = this[receiverName, publisherName];

            if (item == null)
            {
                item = new CaptainHookPublisherRegistryItem
                {
                    PublisherName = publisherName,
                    ReceiverName = receiverName
                };
                InnerList.Add(item);
            }
            return item;
        }

        public CaptainHookPublisherRegistryItem this[string receiver, string publisher]
        {
            get
            {
                return InnerList.Find(x => string.Equals(x.ReceiverName, receiver, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(x.PublisherName, publisher, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    public class CaptainHookPublisherRegistryItem : List<CaptainHookEventPublisher>
    {
        public string ReceiverName { get; set; }
        public string PublisherName { get; set; }

        public CaptainHookPublisherRegistryItem Append<THandler>(string eventName)
        {
            var item = new CaptainHookEventPublisher
            {
                EventName = eventName,
                Type = typeof(THandler)
            };
            Add(item);
            return this;
        }
    }

    public class CaptainHookEventPublisher
    {
        public string EventName { get; set; }
        public Type Type { get; set; }
    }
}
