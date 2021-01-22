using Volo.Abp.Modularity;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookApplicationModule),
        typeof(CaptainHookDomainTestModule)
        )]
    public class CaptainHookApplicationTestModule : AbpModule
    {

    }
}