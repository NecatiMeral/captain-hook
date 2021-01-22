using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CaptainHook.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See CaptainHookDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class CaptainHookMigrationsDbContext : AbpDbContext<CaptainHookMigrationsDbContext>
    {
        public CaptainHookMigrationsDbContext(DbContextOptions<CaptainHookMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            /* Configure your own tables/entities inside the ConfigureCaptainHook method */

            builder.ConfigureCaptainHook();
        }
    }
}