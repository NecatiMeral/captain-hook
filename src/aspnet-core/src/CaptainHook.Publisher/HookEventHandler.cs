using CaptainHook.Publishers;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.EventBus
{
    public class HookEventHandler : IDistributedEventHandler<HookEvent>, ITransientDependency
    {
        protected ICaptainHookPublisherProcessor Processor { get; }

        public HookEventHandler(ICaptainHookPublisherProcessor processor)
        {
            Processor = processor;
        }

        public async Task HandleEventAsync(HookEvent eventData)
        {
            await Processor.HandleEventAsync(eventData);
        }
    }
}
