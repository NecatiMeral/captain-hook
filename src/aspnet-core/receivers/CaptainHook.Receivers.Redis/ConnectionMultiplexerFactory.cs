using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Receivers.Redis
{
    public class ConnectionMultiplexerFactory : IConnectionMultiplexerFactory, ISingletonDependency, IDisposable
    {
        protected IServiceScope ServiceScope { get; }

        public ConnectionMultiplexerFactory(IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScope = serviceScopeFactory.CreateScope();
        }

        public async Task<IConnectionMultiplexer> CreateAsync(string configuration)
        {
            return await ConnectionMultiplexer.ConnectAsync(configuration);
        }

        public void Dispose()
        {
            ServiceScope?.Dispose();
        }
    }
}
