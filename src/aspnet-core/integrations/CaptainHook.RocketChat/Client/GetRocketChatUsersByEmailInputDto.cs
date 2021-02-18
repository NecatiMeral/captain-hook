namespace CaptainHook.RocketChat
{
    public class GetRocketChatUsersByEmailInputDto : RocketChatInputDto
    {
        public string[] Emails { get; set; }
    }
}
