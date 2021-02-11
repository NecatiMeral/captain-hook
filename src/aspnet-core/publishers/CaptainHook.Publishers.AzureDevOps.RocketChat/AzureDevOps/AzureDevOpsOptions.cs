namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public class AzureDevOpsOptions
    {
        class AuthenticationOptions
        {
            public AuthMode Mode { get; set; } = AuthMode.None;

            public string ClientId { get; set; }
            public string Pat { get; set; }
        }
    }

    public enum AuthMode
    {
        None = 0,
        Pat = 1,
        DeviceProfile = 2
    }
}
