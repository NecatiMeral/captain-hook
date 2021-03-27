using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Graph.Client;
using Microsoft.VisualStudio.Services.Profile;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CaptainHook.AzureDevOps.Client
{
    class CaptainHookGraphHttpClient : GraphCompatHttpClientBase
    {
        public CaptainHookGraphHttpClient(Uri baseUrl, VssCredentials credentials)
            : base(baseUrl, credentials)
        {
        }

        public CaptainHookGraphHttpClient(Uri baseUrl, VssCredentials credentials, VssHttpRequestSettings settings)
            : base(baseUrl, credentials, settings)
        {
        }

        public CaptainHookGraphHttpClient(Uri baseUrl, VssCredentials credentials, params DelegatingHandler[] handlers)
            : base(baseUrl, credentials, handlers)
        {
        }

        public CaptainHookGraphHttpClient(Uri baseUrl, HttpMessageHandler pipeline, bool disposeHandler)
            : base(baseUrl, pipeline, disposeHandler)
        {
        }

        public CaptainHookGraphHttpClient(Uri baseUrl, VssCredentials credentials, VssHttpRequestSettings settings, params DelegatingHandler[] handlers)
            : base(baseUrl, credentials, settings, handlers)
        {
        }

        /// <summary>
        /// Alternative implementation of <see cref="GraphHttpClient.GetAvatarAsync(string, AvatarSize?, string, object, CancellationToken)"/> 
        /// since this endpoint uses another location-id (`801eaf9c-0585-4be8-9cdb-b0efa074de91`), which isn't registered on my current Azure DevOps instance.
        /// </summary>
        public async Task<CaptainHookAzureDevOpsAvatar> GetAvatarAsync(string subjectDescriptor, AvatarSize? size = null, string format = null, object userState = null, CancellationToken cancellationToken = default)
        {
            var method = new HttpMethod("GET");
            var locationId = new Guid("d443431f-b341-42e4-85cf-a5b0d639ed8f");
            var routeValues = new
            {
                memberDescriptor = subjectDescriptor
            };
            var collection = new List<KeyValuePair<string, string>>();
            if (size.HasValue)
            {
                collection.Add(nameof(size), size.Value.ToString());
            }
            if (format != null)
            {
                collection.Add(nameof(format), format);
            }

            return await SendAsync<CaptainHookAzureDevOpsAvatar>(method, locationId, routeValues, new ApiResourceVersion(6.0, 1), null, collection, userState, cancellationToken);
        }
    }
}