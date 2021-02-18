using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Client.Authentication
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

        public Task AuthenticateHttpClient(HttpClient httpClient)
        {
            if (options.Mode != AuthMode.Pat)
            {
                throw new NotSupportedException("The HttpClient can only used with a PAT.");
            }

            var pat = Convert.ToBase64String(Encoding.ASCII.GetBytes(
                string.Format("{0}:{1}", string.Empty, options.Pat)
            ));

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", pat);

            return Task.CompletedTask;
        }
    }
}
