using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace CaptainHook.EventBus.RabbitMQ
{
    [DependsOn(
        typeof(AbpEventBusModule)
    )]
    public class CaptainHookDistributedEventBusModule
    {
    }
}
