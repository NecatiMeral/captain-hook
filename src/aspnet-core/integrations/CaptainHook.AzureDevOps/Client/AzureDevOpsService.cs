using Microsoft.VisualStudio.Services.Identity;
using Microsoft.VisualStudio.Services.Identity.Client;
using Microsoft.VisualStudio.Services.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace CaptainHook.AzureDevOps.Client
{
    public class AzureDevOpsService : IAzureDevOpsService, ITransientDependency
    {
        protected IAzureDevOpsConnectionAccessor ConnectionAccessor { get; }
        protected IDistributedCache<AzureDevOpsIdentityDto, Guid> IdentitiesCache { get; }
        protected IObjectMapper<CaptainHookAzureDevOpsModule> ObjectMapper { get; }

        public AzureDevOpsService(IAzureDevOpsConnectionAccessor connectionAccessor,
            IDistributedCache<AzureDevOpsIdentityDto, Guid> identitiesCache,
            IObjectMapper<CaptainHookAzureDevOpsModule> objectMapper)
        {
            ConnectionAccessor = connectionAccessor;
            IdentitiesCache = identitiesCache;
            ObjectMapper = objectMapper;
        }

        public async Task<AzureDevOpsIdentityDto> GetIdentityAsync(Uri collectionUri, Guid identityId)
        {
            // TODO: Consider using `GetManyAsync`
            var identity = await IdentitiesCache.GetOrAddAsync(
                identityId,
                () => GetIdentityFromApiAsync(collectionUri, identityId)
            );

            return identity;
        }

        public async Task<AzureDevOpsIdentityDto[]> GetIdentitiesAsync(Uri collectionUri, Guid[] identityIds)
        {
            var cachedIdentities = await IdentitiesCache.GetManyAsync(
                identityIds
            );

            var identities = cachedIdentities.Where(x => x.Value != null).Select(x => x.Value).ToList();
            var missingIdentityIds = identityIds.Where(x => !identities.Any(i => i.Id == x)).ToArray();
            if (missingIdentityIds.Any())
            {
                var missingIdentities = await GetIdentitiesFromApiAsync(collectionUri, missingIdentityIds);

                var cacheItems = missingIdentities
                    .Select(x => new KeyValuePair<Guid, AzureDevOpsIdentityDto>(x.Id, x))
                    .ToArray();

                await IdentitiesCache.SetManyAsync(cacheItems);

                identities.AddRange(missingIdentities);
            }

            return identities.ToArray();
        }

        public async Task<AzureDevOpsIdentityDto[]> GetAndIterateIdentitiesAsync(Uri collectionUri, Guid[] identityIds)
        {
            var identities = new List<AzureDevOpsIdentityDto>();
            await GetAndIterateIdentitiesImplAsync(identities, collectionUri, identityIds);

            return identities.ToArray();
        }

        async Task GetAndIterateIdentitiesImplAsync(List<AzureDevOpsIdentityDto> knownIdentities, Uri collectionUri, Guid[] identityIds)
        {
            var missingIdentityIds = identityIds.Where(x => !knownIdentities.Any(i => i.Id == x)).ToArray();
            if (!missingIdentityIds.Any())
            {
                return;
            }

            var missingIdentities = await GetIdentitiesAsync(collectionUri, missingIdentityIds);
            var containers = missingIdentities.Where(x => x.IsContainer).ToArray();

            knownIdentities.AddRange(missingIdentities);

            foreach (var containerItem in containers)
            {
                await GetAndIterateIdentitiesImplAsync(knownIdentities, collectionUri, containerItem.MemberIds);
            }
        }

        async Task<AzureDevOpsIdentityDto> GetIdentityFromApiAsync(Uri collectionUri, Guid identityId)
        {
            var connection = await ConnectionAccessor.GetConnectionAsync(collectionUri);
            var client = await connection.GetClientAsync<IdentityHttpClient>();
            var identity = await client.ReadIdentityAsync(identityId, QueryMembership.ExpandedDown);

            if (identity != null)
            {
                return ObjectMapper.Map<Identity, AzureDevOpsIdentityDto>(identity);
            }

            return null;
        }

        async Task<AzureDevOpsIdentityDto[]> GetIdentitiesFromApiAsync(Uri collectionUri, Guid[] identityIds)
        {
            var connection = await ConnectionAccessor.GetConnectionAsync(collectionUri);
            var client = await connection.GetClientAsync<IdentityHttpClient>();

            var identitiesCollection = await client.ReadIdentitiesAsync(identityIds, QueryMembership.ExpandedDown);

            if (identitiesCollection != null)
            {
                return ObjectMapper.Map<IdentitiesCollection, AzureDevOpsIdentityDto[]>(identitiesCollection);
            }

            return null;
        }

        public async Task<IdentityImageDto> DownloadIdentityImageAsync(Uri collectionUri, Guid identityId)
        {
            using (var client = await ConnectionAccessor.CreateHttpClientAsync(collectionUri))
            {
                using (var response = await client.GetAsync("_api/_common/identityImage?id=" + identityId))
                {
                    response.EnsureSuccessStatusCode();

                    var payload = await response.Content.ReadAsByteArrayAsync();

                    return new IdentityImageDto
                    {
                        Payload = payload,
                        MediaType = response.Content.Headers.ContentType.MediaType
                    };
                }
            }
        }

        public async Task<IdentityImageDto> DownloadGraphAvatarAsync(Uri collectionUri, string descriptor)
        {
            var connection = await ConnectionAccessor.GetConnectionAsync(collectionUri);

            using (var client = await connection.GetClientAsync<CaptainHookGraphHttpClient>())
            {
                var avatar = await client.GetAvatarAsync(descriptor, AvatarSize.Medium);

                if (avatar.ImageData != null)
                {
                    return new IdentityImageDto
                    {
                        Payload = avatar.ImageData,
                        MediaType = avatar.ImageType
                    };
                }
                return null;
            }
        }
    }
}