using System.Threading.Tasks;

namespace CaptainHook.Data
{
    public interface ICaptainHookDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
