using CaptainHook.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherManager : ICaptainHookPublisherManager, ISingletonDependency
    {
        public ILogger<CaptainHookPublisherManager> Logger { get; set; }

        protected IHybridServiceScopeFactory ServiceScopeFactory { get; }
        protected IDistributedEventBus EventBus { get; }
        protected CaptainHookPublisherOptions Options { get; }
        protected CaptainHookPublisherRegistryOptions Registry { get; }

        public ConcurrentDictionary<string, Type> EventTypes { get; }

        public CaptainHookPublisherManager(
            IHybridServiceScopeFactory serviceScopeFactory,
            IDistributedEventBus eventBus,
            IOptions<CaptainHookPublisherOptions> options,
            IOptions<CaptainHookPublisherRegistryOptions> registry)
        {
            ServiceScopeFactory = serviceScopeFactory;
            EventBus = eventBus;
            Options = options.Value;
            Registry = registry.Value;

            EventTypes = new ConcurrentDictionary<string, Type>();

            Logger = NullLogger<CaptainHookPublisherManager>.Instance;
        }

        public void Initialize()
        {
            foreach (var configItem in Options.Publish)
            {
                var reg = Registry.PublisherHandlers[configItem.ReceiveFrom, configItem.PublishTo];
                if (reg == null)
                {
                    throw new NotImplementedException($"No publisher registered to process events from `{configItem.ReceiveFrom}` to `{configItem.PublishTo}`.");
                }
                else if (reg.Count == 0)
                {
                    Logger.LogWarning("Publisher for `{0}` » `{1}` doesn't have any event handlers. This is probably a bug in your registration.",
                        reg.ReceiverName, reg.PublisherName);
                }

                foreach (var eventHandler in reg)
                {
                    Logger.LogInformation("Registering receiver `{0}:{1}` to handle events of type `{2}` with identifier `{3}`",
                        reg.ReceiverName, eventHandler.Type.FullName, eventHandler.EventName, configItem.Identifier);

                    var key = CaptainHookPublisherProcessor.CalculateKey(reg.ReceiverName, configItem.Identifier, eventHandler.EventName);

                    EventTypes[key] = eventHandler.Type;
                }
            }
        }
    }
}
