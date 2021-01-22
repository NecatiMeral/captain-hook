using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace CaptainHook
{
    [DependsOn(
        typeof(AbpHttpClientModule)
    )]
    public class CaptainHookHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CaptainHookApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
