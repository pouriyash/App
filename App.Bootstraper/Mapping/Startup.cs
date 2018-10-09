using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static App.DomainServices.Repositories.message;

namespace App.Bootstraper
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessagesService, MessagesService>();

        }
    }
}
