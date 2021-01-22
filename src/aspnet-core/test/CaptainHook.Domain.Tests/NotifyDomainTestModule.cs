using CaptainHook.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookEntityFrameworkCoreTestModule)
        )]
    public class CaptainHookDomainTestModule : AbpModule
    {

    }
}