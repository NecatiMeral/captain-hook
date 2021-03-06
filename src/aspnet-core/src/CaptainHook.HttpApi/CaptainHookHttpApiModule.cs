﻿using Localization.Resources.AbpUi;
using CaptainHook.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookApplicationContractsModule),
        typeof(CaptainHookDomainModule),
        typeof(AbpAspNetCoreMvcModule)
    )]
    public class CaptainHookHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CaptainHookResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
