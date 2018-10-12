using App.Data.Sql.Context;
using App.DomainModels.ViewModels.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
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
            services.AddDbContext<AppDbContext>();

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
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/images/error.svg");
            }

            app.UseFileServer();


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
