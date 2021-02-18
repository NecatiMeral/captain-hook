using CaptainHook.AzureDevOps.Client.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.AzureDevOps.Client
{
    public class AzureDevOpsConnectionAccessor : IAzureDevOpsConnectionAccessor, ITransientDependency
    {
        protected AzureDevOpsOptions Options { get; }
        protected IHttpClientFactory HttpClientFactory { get; }
        protected IAzureDevOpsAuthenticator Authenticator { get; }

        public AzureDevOpsConnectionAccessor(
            IOptions<AzureDevOpsOptions> options,
            IHttpClientFactory httpClientFactory,
            IAzureDevOpsAuthenticator authenticator)
        {
            Options = options.Value;
            HttpClientFactory = httpClientFactory;
            Authenticator = authenticator;
        }

        public async Task<VssConnection> GetConnectionAsync(Uri collectionUri)
        {
            var credentials = await Authenticator.CreateCredentials();
            var connection = new VssConnection(collectionUri, credentials);

            return connection;
        }

        public async Task<HttpClient> CreateHttpClientAsync(Uri collectionUri)
        {
            var httpClient = HttpClientFactory.CreateClient("AzureDevOps");

            httpClient.BaseAddress = collectionUri;

            await Authenticator.AuthenticateHttpClient(httpClient);

            return httpClient;
        }
    }
}
