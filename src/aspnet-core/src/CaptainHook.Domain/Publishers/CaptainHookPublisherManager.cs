using CaptainHook.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Reflection;

namespace CaptainHook.Publishers
{
    public class CaptainHookPublisherManager : ICaptainHookPublisherManager, ISingletonDependency
    {
        public ILogger<CaptainHookPublisherManager> Logger { get; set; }

        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected CaptainHookPublisherOptions Options { get; }
        protected CaptainHookPublisherRegistryOptions Registry { get; }

        protected ConcurrentDictionary<string, Type> EventTypes { get; }

        public CaptainHookPublisherManager(IServiceScopeFactory serviceScopeFactory,
            IOptions<CaptainHookPublisherOptions> options,
            IOptions<CaptainHookPublisherRegistryOptions> registry)
        {
            ServiceScopeFactory = serviceScopeFactory;
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
                    var key = CalculateKey(reg.ReceiverName, configItem.Identifier, eventHandler.EventName);

                    EventTypes[key] = eventHandler.Type;
                }
            }
        }

        string CalculateKey(string receiverName, string identifier, string eventName)
            => $"{receiverName}.{identifier}.{eventName}";

        public async Task HandleEventAsync(HookEvent eventData)
        {
            var key = CalculateKey(eventData.ReceiverName, eventData.Id, eventData.EventType);

            if (!EventTypes.ContainsKey(key))
            {
                return;
            }

            var handlerType = EventTypes[key];

            if (ReflectionHelper.IsAssignableToGenericType(handlerType, typeof(IEventPublisher<>)))
            {
                var genericImplementations = ReflectionHelper.GetImplementedGenericTypes(handlerType, typeof(IEventPublisher<>));
                if (genericImplementations.Count != 1)
                {
                    return;
                }

                var implementedPayloadTypes = genericImplementations[0].GetGenericArguments();
                if (implementedPayloadTypes.Length != 1)
                {
                    return;
                }

                var payloadType = implementedPayloadTypes[0];
                var json = (JsonElement)eventData.Payload;
                var payload = ToObject(json, payloadType);

                var parameterType = typeof(HookEventToPublish<>).MakeGenericType(payloadType);
                var eventWrapper = Activator.CreateInstance(parameterType, new[] { eventData, payload });

                using (var scope = ServiceScopeFactory.CreateScope())
                {
                    var receiver = (IEventPublisher)scope.ServiceProvider.GetRequiredService(handlerType);
                    var method = typeof(IEventPublisher<>)
                        .MakeGenericType(payloadType)
                        .GetMethod(
                            nameof(IEventPublisher<object>.HandleEventAsync),
                            new[] { parameterType }
                        );

                    await (Task)method.Invoke(receiver, new[] { eventWrapper });
                }
            }
            else
            {
                throw new AbpException("The object instance is not an event handler. Object type: " + handlerType.AssemblyQualifiedName);
            }

        }

        object ToObject(JsonElement element, Type returnType)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize(json, returnType);
        }
    }
}
