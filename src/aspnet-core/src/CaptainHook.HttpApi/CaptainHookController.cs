using CaptainHook.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CaptainHook
{
    /* Inherit your controllers from this class.
     */
    public abstract class CaptainHookController : AbpController
    {
        protected CaptainHookController()
        {
            LocalizationResource = typeof(CaptainHookResource);
        }
    }
}