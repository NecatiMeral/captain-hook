using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace CaptainHook.Publishers
{
    public class HookEventHandlerFactory : IocEventHandlerFactory, IScopedDependency
    {
        public HookEventHandlerFactory(IServiceScopeFactory scopeFactory, Type handlerType)
            : base(scopeFactory, handlerType)
        {
        }
    }
}
