using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.Data
{
    /* This is used if database provider does't define
     * ICaptainHookDbSchemaMigrator implementation.
     */
    public class NullCaptainHookDbSchemaMigrator : ICaptainHookDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}