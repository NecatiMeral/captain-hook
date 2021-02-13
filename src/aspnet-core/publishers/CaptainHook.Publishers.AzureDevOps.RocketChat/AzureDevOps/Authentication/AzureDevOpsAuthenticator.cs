using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps.Authentication
{
    public class AzureDevOpsAuthenticator : IAzureDevOpsAuthenticator, ITransientDependency
    {
        private AzureDevOpsAuthenticationOptions options;

        public AzureDevOpsAuthenticator(IOptions<AzureDevOpsAuthenticationOptions> options)
        {
            this.options = options.Value;
        }

        public Task<VssCredentials> CreateCredentials()
        {
            VssCredentials credentials;

            switch (options.Mode)
            {
                case AuthMode.Pat:
                    credentials = new VssBasicCredential(string.Empty, options.Pat);
                    break;
                case AuthMode.Windows:
                    credentials = new WindowsCredential();
                    break;
                default:
                    throw new NotImplementedException($"Invalid authentication mode `{options.Mode}`");
            }

            return Task.FromResult(credentials);
        }
    }
}
