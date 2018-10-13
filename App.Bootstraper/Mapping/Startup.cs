using App.Bootstraper.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static App.DomainServices.Repositories.message;

namespace App.Bootstraper
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessagesService, MessagesService>();

            //استفاده از reflection برای معرفی مپینگ ها اتومپر
            services.AddAutoMapper(typeof(MappingProfile).GetTypeInfo().Assembly);

        }
    }
}
