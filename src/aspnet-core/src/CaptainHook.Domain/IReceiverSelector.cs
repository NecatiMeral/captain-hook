using CaptainHook.Receivers;
using System;

namespace CaptainHook
{
    public interface IReceiverSelector
    {
        Type Select(IWebHookExecutionContext context);
    }
}
