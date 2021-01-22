using System;
using System.Collections.Generic;
using System.Text;
using CaptainHook.Localization;
using Volo.Abp.Application.Services;

namespace CaptainHook
{
    /* Inherit your application services from this class.
     */
    public abstract class CaptainHookAppService : ApplicationService
    {
        protected CaptainHookAppService()
        {
            LocalizationResource = typeof(CaptainHookResource);
        }
    }
}
