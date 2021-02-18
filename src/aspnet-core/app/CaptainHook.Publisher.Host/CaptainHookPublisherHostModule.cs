using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Caching.StackExchangeRedis;
using CaptainHook.EntityFrameworkCore;
using CaptainHook.Receivers;
using CaptainHook.AzureDevOps.RocketChat.Publishers;

namespace CaptainHook
{
    [DependsOn(
        typeof(CaptainHookHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(CaptainHookApplicationModule),
        typeof(CaptainHookEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(CaptainHookAzureDevOpsRocketChatPublishersModule),
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class CaptainHookPublisherHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureVirtualFileSystem(context);
            ConfigureWebHookReceivers(configuration);
            ConfigureCors(context, configuration);
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    var sourcePath = Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}src{Path.DirectorySeparatorChar}");
                    options.FileSets.ReplaceEmbeddedByPhysical<CaptainHookDomainSharedModule>(
                        Path.Combine(sourcePath, "CaptainHook.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<CaptainHookDomainModule>(
                        Path.Combine(sourcePath, "CaptainHook.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<CaptainHookApplicationContractsModule>(
                        Path.Combine(sourcePath, "CaptainHook.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<CaptainHookApplicationModule>(
                        Path.Combine(sourcePath, "CaptainHook.Application"));
                });
            }
        }

        private void ConfigureWebHookReceivers(IConfiguration configuration)
        {
            Configure<CaptainHookReceiverOptions>(configuration.GetSection("CaptainHook"));
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "CaptainHook";
                    options.BackchannelHttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            app.UseAuthorization();

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
