﻿using Microsoft.VisualStudio.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaptainHook.Publishers.AzureDevOps.RocketChat.AzureDevOps.Authentication
{
    public interface IAzureDevOpsAuthenticator
    {
        Task<VssCredentials> CreateCredentials();
        Task AuthenticateHttpClient(HttpClient httpClient);
    }
}
