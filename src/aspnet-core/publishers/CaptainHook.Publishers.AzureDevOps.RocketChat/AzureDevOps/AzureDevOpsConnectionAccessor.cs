using CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps
{
    public class AzureDevOpsConnectionAccessor : IAzureDevOpsConnectionAccessor, ITransientDependency
    {
        protected AzureDevOpsOptions Options { get; }
        protected IAzureDevOpsAuthenticator Authenticator { get; }

        public AzureDevOpsConnectionAccessor(IOptions<AzureDevOpsOptions> options, IAzureDevOpsAuthenticator authenticator)
        {
            Options = options.Value;
            Authenticator = authenticator;
        }

        public async Task<VssConnection> GetConnectionAsync(Uri collectionUri)
        {
            var credentials = await Authenticator.CreateCredentials();
            var connection = new VssConnection(collectionUri, credentials);

            return connection;
        }
    }
}
