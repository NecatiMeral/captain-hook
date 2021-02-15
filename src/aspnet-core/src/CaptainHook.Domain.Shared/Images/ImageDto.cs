namespace CaptainHook.Images
{
    public class ImageDto
    {
        public string MediaType { get; set; }
        public byte[] Payload { get; set; }

        public static string CalculateCacheKey(string providerName, string imageId)
        {
            return $"{providerName}|{imageId}";
        }
    }
}
