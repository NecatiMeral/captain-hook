namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public class AzureDevOpsUserService
    {
        protected IAzureDevOpsConnectionAccessor ConnectionAccessor { get; }

        public AzureDevOpsUserService(IAzureDevOpsConnectionAccessor connectionAccessor)
        {
            ConnectionAccessor = connectionAccessor;
        }

        public object GetIdentitiesInReviewersAsync()
        {

        }
    }
}
