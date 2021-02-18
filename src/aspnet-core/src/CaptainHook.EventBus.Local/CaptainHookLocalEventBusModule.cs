using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace CaptainHook.EventBus.Local
{
    [DependsOn(
        typeof(AbpEventBusModule)
    )]
    public class CaptainHookLocalEventBusModule
    {
    }
}
