using CaptainHook.Receivers.Queue;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Reflection;

namespace CaptainHook.Receivers
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule)
        )]
    public class CaptainHookReceiverModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AddEventProcessors(context.Services);
        }

        private static void AddEventProcessors(IServiceCollection services)
        {
            var localHandlers = new List<Type>();

            services.OnRegistred(context =>
            {
                if (ReflectionHelper.IsAssignableToGenericType(context.ImplementationType, typeof(IEventQueueHandler<>)))
                {
                    localHandlers.Add(context.ImplementationType);
                }
            });

            services.Configure<EventQueueOptions>(options =>
            {
                options.EventProcessors.AddIfNotContains(localHandlers);
            });
        }
    }
}
