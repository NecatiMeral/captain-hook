using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace CaptainHook.EntityFrameworkCore
{
    public static class CaptainHookDbContextModelCreatingExtensions
    {
        public static void ConfigureCaptainHook(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(CaptainHookConsts.DbTablePrefix + "YourEntities", CaptainHookConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}