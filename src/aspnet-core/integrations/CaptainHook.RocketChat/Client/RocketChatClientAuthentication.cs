namespace CaptainHook.RocketChat
{
    public class RocketChatClientAuthentication
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string AuthToken { get; set; }

        public static string CalculateCacheKey(string baseUrl, string username)
        {
            return $"{baseUrl}-{username}";
        }
    }
}
