using CaptainHook.Queue;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace CaptainHook.Receivers.Redis.Queue
{
    public class RedisEventQueue : IEventQueue, ISingletonDependency
    {
        protected IConnectionMultiplexerFactory ConnectionMultiplexerFactory { get; }
        protected IJsonSerializer JsonSerializer { get; }
        protected RedisEventQueueOptions Options { get; }

        protected IConnectionMultiplexer ConnectionMultiplexer { get; private set; }

        public RedisEventQueue(IConnectionMultiplexerFactory connectionMultiplexerFactory, IJsonSerializer jsonSerializer,
            IOptions<RedisEventQueueOptions> options)
        {
            ConnectionMultiplexerFactory = connectionMultiplexerFactory;
            JsonSerializer = jsonSerializer;
            Options = options.Value;
        }

        public async Task InitializeAsync()
        {
            ConnectionMultiplexer = await ConnectionMultiplexerFactory.CreateAsync(Options.Configuration);
        }

        public async Task PublishAsync<T>(string receiverName, string id, string eventType, T payload)
        {
            var sub = ConnectionMultiplexer.GetSubscriber();
            var channel = $"{receiverName}-{id}-{eventType}";
            var payloadJson = JsonSerializer.Serialize(channel);

            await sub.PublishAsync(channel, payloadJson);
        }

        public async Task<IDisposable> SubscribeAsync<T>(string receiverName, string id, string eventType, Func<T, Task> handler)
        {
            var sub = ConnectionMultiplexer.GetSubscriber();
            var channel = $"{receiverName}-{id}-{eventType}";
            var handlerWrapper = Subscribe(handler);

            await sub.SubscribeAsync(channel, handlerWrapper);

            return new SubscriberGuard(sub, channel, handlerWrapper);
        }

        private Action<RedisChannel, RedisValue> Subscribe<T>(Func<T, Task> handler)
        {
            return async (_, value) =>
            {
                T resultFromCache = JsonSerializer.Deserialize<T>(value, true);
                await handler(resultFromCache);
            };
        }

        class SubscriberGuard : IDisposable
        {
            private bool disposedValue;

            public ISubscriber Sub { get; }
            public string Key { get; }
            public Action<RedisChannel, RedisValue> Handler { get; }

            public SubscriberGuard(ISubscriber sub, string key, Action<RedisChannel, RedisValue> handler)
            {
                Sub = sub;
                Key = key;
                Handler = handler;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        Sub.Unsubscribe(Key, Handler);
                    }

                    // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                    // TODO: Große Felder auf NULL setzen
                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
