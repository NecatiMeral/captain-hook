namespace CaptainHook.AzureDevOps.RocketChat.Publishers.Client
{
    public class GetRocketChatUsersByEmailInputDto : RocketChatInputDto
    {
        public string[] Emails { get; set; }
    }
}
