using Volo.Abp.Collections;
using Volo.Abp.EventBus;

namespace CaptainHook.Queue
{
    public class EventQueueOptions
    {
        public ITypeList<IEventHandler> EventProcessors { get; }

        public EventQueueOptions()
        {
            EventProcessors = new TypeList<IEventHandler>();
        }
    }
}
