using CaptainHook.EventBus;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using CaptainHook.AzureDevOps.Payload;
using CaptainHook.Publishers;
using CaptainHook.RocketChat;

namespace CaptainHook.AzureDevOps.RocketChat.Publisher.Code
{
    public class PipelineRunStateChangedHandler : IEventPublisher<PipelineRunStateChangedPayload>, ITransientDependency
    {
        protected IRocketChatClient RocketChatWebHookClient { get; }

        public PipelineRunStateChangedHandler(IRocketChatClient rocketChatWebHookClient)
        {
            RocketChatWebHookClient = rocketChatWebHookClient;
        }

        public async Task HandleEventAsync(HookEventToPublish<PipelineRunStateChangedPayload> eventData)
        {
            var payload = eventData.Payload;

            var message = new MessageDto
            {
                Text = payload.Message.Markdown,
                Channel = "@nm"
            };

            await RocketChatWebHookClient.SendMessage(message);
        }
    }
}
