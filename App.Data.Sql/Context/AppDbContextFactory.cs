using App.DomainModels.ViewModels.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace App.Data.Sql.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        /// <summary>
        /// Just FOr Migration
        /// چون سازنده DbContext دارای پارامتر است باید یک کلاس که از اینترفیس IDesignTimeDbContextFactory ارثبری کرده است بسازیم و DbContext را با پارامترهایش پر کنیم و بازگردانیم. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            var basePath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Using `{basePath}` as the ContentRootPath");
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .Build();
            services.AddSingleton<IConfigurationRoot>(provider => configuration);
            services.Configure<SiteSettings>(options => configuration.Bind(options));

            var siteSettings = services.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<SiteSettings>>();

            services.AddRequiredEfInternalServices(siteSettings.Value); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.SetDbContextOptions(siteSettings.Value);
            optionsBuilder.UseInternalServiceProvider(services.BuildServiceProvider()); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.

            //builder.UseSqlServer(@"Data Source=DESKTOP-80FGNLP\POURIYA;Initial Catalog=NewAppTest;Persist Security Info=True;User ID=sa; Password=123; MultipleActiveResultSets=True");
            //builder.UseSqlServer(@"Server=WIN-SQL\\MSSQLSERVER2016;Initial Catalog=NewAppTest;Persist Security Info=True;User ID=sa; Password=exir@123; MultipleActiveResultSets=True");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
