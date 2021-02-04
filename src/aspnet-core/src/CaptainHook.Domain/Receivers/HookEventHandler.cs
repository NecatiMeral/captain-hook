using CaptainHook.EventBus;
using CaptainHook.Publishers;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CaptainHook.Receivers
{
    public class HookEventHandler : IDistributedEventHandler<HookEvent>, ITransientDependency
    {
        protected ICaptainHookPublisherManager Manager { get; }

        public HookEventHandler(ICaptainHookPublisherManager manager)
        {
            Manager = manager;
        }

        public async Task HandleEventAsync(HookEvent eventData)
        {
            await Manager.HandleEventAsync(eventData);
        }
    }
}
