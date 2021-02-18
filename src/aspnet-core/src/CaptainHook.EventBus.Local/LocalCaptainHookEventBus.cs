using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace CaptainHook.EventBus.Local
{
    public class LocalCaptainHookEventBus : EventBusWrapper, ISingletonDependency
    {
        public LocalCaptainHookEventBus(ILocalEventBus localEventBus)
            : base(localEventBus)
        {
        }
    }
}
