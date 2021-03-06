﻿using App.Bootstraper.identity;
using App.Data.Sql.Context;
using App.DomainModels.SSOT;
using App.DomainModels.Validation;
using App.DomainModels.ViewModels.Settings;
using App.DomainServices.Validation;
using AutoMapper;
using DNTCaptcha.Core;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static App.DomainServices.Repositories.message;

namespace App.Admin
{
    public class Startup
    {
        public IConfiguration _Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _Configuration = configuration;

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //بایند کردن موجودیت ConnectionStrings از appsetting به Model  مورد نظر
            services.Configure<SiteSettings>(options => _Configuration.Bind(options));

            services.Configure<FileConfig>(options => _Configuration.GetSection("FileConfig").Bind(options));
            // Explicitly register the settings object by delegating to the IOptions object
            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<FileConfig>>().Value);

            var siteSettings = services.GetSiteSettings();
            services.AddRequiredEfInternalServices(siteSettings); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.

            Bootstraper.StartUp.ConfigureServices(services, _Configuration);
            // Adds all of the ASP.NET Core Identity related services and configurations at once.

            services.AddDbContextPool<AppDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.SetDbContextOptions(siteSettings);
                optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            });




            ///Dependency Injection          
            services.AddMvc(options =>
            {
                options.UseYeKeModelBinder();
                options.AllowEmptyInputInBodyModelBinding = true;
                // options.Filters.Add(new NoBrowserCacheAttribute());
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region PocoConfigure Validation

            services.AddTransient<IStartupFilter, SettingValidationStartupFilter>();
            // Bind the configuration using IOptions

            #region FileConfig Validation

            services.AddSingleton(resolver =>
               resolver.GetRequiredService<IOptions<FileConfig>>().Value);

            services.AddSingleton<IValidatable>(resolver =>
               resolver.GetRequiredService<IOptions<FileConfig>>().Value);

            #endregion

            #region SiteSettings Validation

            services.AddSingleton(resolver =>
               resolver.GetRequiredService<IOptions<SiteSettings>>().Value);

            services.AddSingleton<IValidatable>(resolver =>
               resolver.GetRequiredService<IOptions<SiteSettings>>().Value);

            #endregion

            #endregion
            
            services.AddDNTCaptcha();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IConfiguration configuration, IHostingEnvironment env, IMessagesService messagesService)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/images/error.svg");
            }

            app.UseHttpsRedirection();
            app.UseFileServer();

            // Adds all of the ASP.NET Core Identity related initializations at once.
            app.UseCustomIdentityServices();
            //نمیدونم چیه.باید تحقیق شود
            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async context =>
            //{
            //    var siteName = messagesService.GetSiteName();
            //    await context.Response.WriteAsync($"Hello {siteName}");
            //});
        }
    }
}
