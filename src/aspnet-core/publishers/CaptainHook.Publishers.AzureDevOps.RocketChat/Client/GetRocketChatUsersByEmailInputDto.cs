namespace CaptainHook.Publishers.AzureDevOps.RocketChat.Client
{
    public class GetRocketChatUsersByEmailInputDto : RocketChatInputDto
    {
        public string[] Emails { get; set; }
    }
}
