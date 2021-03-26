using System;
using System.Collections.Generic;
using Volo.Abp.Collections;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherRegistry
    {
        List<CaptainHookPublisherRegistryItem> InnerList;

        public CaptainHookPublisherRegistry()
        {
            InnerList = new List<CaptainHookPublisherRegistryItem>();
        }

        /// <summary>
        /// Registers a combination of receiver / handler and provides a registry item to register item to add handlers for specific event types
        /// </summary>
        /// <param name="receiverName">The receiver to handle events from</param>
        /// <param name="publisherName">The publisher to process events for</param>
        /// <returns></returns>
        public CaptainHookPublisherRegistryItem GetOrAdd(string receiverName, string publisherName)
        {
            var item = this[receiverName, publisherName];

            if (item == null)
            {
                item = new CaptainHookPublisherRegistryItem(receiverName, publisherName);
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

        public List<Type> ScopedDependencies { get; }

        public CaptainHookPublisherRegistryItem(string receiverName, string publisherName)
        {
            ReceiverName = receiverName;
            PublisherName = publisherName;
            ScopedDependencies = new List<Type>();
        }

        public CaptainHookPublisherRegistryItem Append<THandler>(string eventName)
        {
            var item = new CaptainHookEventPublisher(eventName, typeof(THandler));
            Add(item);
            return this;
        }

        public CaptainHookPublisherRegistryItem AppendScopedDependency<TDependency>()
        {
            ScopedDependencies.Add(typeof(TDependency));
            return this;
        }
    }

    public record CaptainHookEventPublisher(string EventName, Type Type);
}
