using CaptainHook.Receivers;

namespace CaptainHook
{
    class DefaultWebHookExecutionContext : IWebHookExecutionContext
    {
        public string Name { get; }

        public string Id { get; }

        public dynamic Content { get; }

        public DefaultWebHookExecutionContext(string name, string id, dynamic content)
        {
            Name = name;
            Id = id;
            Content = content;
        }

    }
}
