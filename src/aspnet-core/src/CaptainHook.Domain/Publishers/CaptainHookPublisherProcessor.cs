using CaptainHook.EventBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Reflection;

namespace CaptainHook.Publishers
{
    class CaptainHookPublisherProcessor : ICaptainHookPublisherProcessor, IScopedDependency
    {
        protected IServiceProvider ServiceProvider { get; }
        protected ICaptainHookPublisherManager CaptainHookPublisherManager { get; }
        protected IHookEventContextProvider HookEventContextProvider { get; }

        public CaptainHookPublisherProcessor(
            IServiceProvider serviceProvider,
            ICaptainHookPublisherManager captainHookPublisherManager,
            IHookEventContextProvider hookEventContextProvider)
        {
            ServiceProvider = serviceProvider;
            CaptainHookPublisherManager = captainHookPublisherManager;
            HookEventContextProvider = hookEventContextProvider;
        }

        public static string CalculateKey(string receiverName, string identifier, string eventName)
            => $"{receiverName}.{identifier}.{eventName}";

        public async Task HandleEventAsync(HookEvent eventData)
        {
            var eventTypes = CaptainHookPublisherManager.EventTypes;
            var key = CalculateKey(eventData.ReceiverName, eventData.Id, eventData.EventType);

            if (!eventTypes.ContainsKey(key))
            {
                return;
            }

            var handlerType = eventTypes[key];

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

                HookEventContextProvider.SetContext(eventData);

                var payloadType = implementedPayloadTypes[0];
                var json = (JsonElement)eventData.Payload;
                var parameterType = typeof(HookEventToPublish<>).MakeGenericType(payloadType);

                var payload = ToObject(json, payloadType);
                var eventWrapper = Activator.CreateInstance(parameterType, new[] { eventData, payload });

                var receiver = (IEventPublisher)ServiceProvider.GetRequiredService(handlerType);
                var method = typeof(IEventPublisher<>)
                    .MakeGenericType(payloadType)
                    .GetMethod(
                        nameof(IEventPublisher<object>.HandleEventAsync),
                        new[] { parameterType }
                    );

                await (Task)method.Invoke(receiver, new[] { eventWrapper });
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
