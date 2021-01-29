using CaptainHook.Receivers.Redis.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Reflection;
using Volo.Abp.Threading;

namespace CaptainHook.Receivers.Redis
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class CaptainHookReceiverRedisModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<RedisEventQueueOptions>(configuration.GetSection("Redis"));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(
                () => context
                    .ServiceProvider
                    .GetRequiredService<RedisEventQueue>()
                    .InitializeAsync()
            );
        }
    }
}
