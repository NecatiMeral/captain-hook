using System;
using System.Collections.Concurrent;

namespace CaptainHook.Publishers
{
    /// <summary>
    /// Receives and delegates events to the configured publishers.
    /// </summary>
    public interface ICaptainHookPublisherManager
    {
        ConcurrentDictionary<string, Type> EventTypes { get; }
    }
}