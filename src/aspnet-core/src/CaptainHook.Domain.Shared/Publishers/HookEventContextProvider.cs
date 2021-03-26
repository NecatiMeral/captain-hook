using System;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers
{
    public class HookEventContextProvider : IHookEventContextProvider, IScopedDependency
    {
        protected IHookEventContext Context { get; private set; }

        public HookEventContextProvider()
        {
        }

        public IHookEventContext GetContext()
        {
            if (Context == null)
            {
                throw new InvalidOperationException("The context must be provided first.");
            }
            return Context;
        }

        public void SetContext(IHookEventContext context)
        {
            if (Context != null)
            {
                throw new InvalidOperationException("The context can only set once.");
            }
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
