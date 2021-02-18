using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.EventBus.Local
{
    public class RabbitMQCaptainHookEventBus : EventBusWrapper, ISingletonDependency
    {
        public RabbitMQCaptainHookEventBus(IDistributedEventBus localEventBus)
            : base(localEventBus)
        {
        }
    }
}
