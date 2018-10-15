using App.Data.Sql.Context;
using App.DomainModels.ViewModels.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static App.DomainServices.Repositories.message;

namespace App.Bootstraper
{
    public static class StartUp
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, AppDbContext>();
            services.AddTransient<IMessagesService, MessagesService>();

            //بایند کردن موجودیت ConnectionStrings از appsetting به Model  مورد نظر
            services.Configure<ConnectionString>(options => configuration.GetSection("ConnectionStrings").Bind(options));
            services.AddScoped<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("ConnectionStrings")));

            //اتصال connectionStrings به AppDbContext
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));
        }
    }
}
