using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.DomainModels.ViewModels.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using static App.DomainServices.Repositories.message;

namespace App.Admin
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            ///Dependency Injection
            Bootstraper.Startup.ConfigureServices(services);            
            services.Configure<ConnectionString>(options => Configuration.GetSection("ConnectionStrings").Bind(options));
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IConfiguration configuration, IHostingEnvironment env, IMessagesService messagesService)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/images/error.svg");
            }

            app.UseFileServer();
            app.UseMvcWithDefaultRoute();

            //app.Run(async context =>
            //{
            //    var siteName = messagesService.GetSiteName();
            //    await context.Response.WriteAsync($"Hello {siteName}");
            //});


        }
    }
}
