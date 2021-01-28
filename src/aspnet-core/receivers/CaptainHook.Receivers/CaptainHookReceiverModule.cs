using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace CaptainHook.Receivers
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule)
        )]
    public class CaptainHookReceiverModule : AbpModule
    {
        //public override void PreConfigureServices(ServiceConfigurationContext context)
        //{
        //    AddEventProcessors(context.Services);
        //}

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<CaptainHookProcessingOptions>(configuration.GetSection("CaptainHook"));
        }

        //private static void AddEventProcessors(IServiceCollection services)
        //{
        //    var localHandlers = new List<Type>();

        //    services.OnRegistred(context =>
        //    {
        //        if (ReflectionHelper.IsAssignableToGenericType(context.ImplementationType, typeof(IEventQueueHandler<>)))
        //        {
        //            localHandlers.Add(context.ImplementationType);
        //        }
        //    });

        //    services.Configure<EventQueueOptions>(options =>
        //    {
        //        options.EventProcessors.AddIfNotContains(localHandlers);
        //    });
        //}
    }
}
