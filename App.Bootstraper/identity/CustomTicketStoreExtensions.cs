using App.Data.Sql.Context;
using App.DomainModels.ViewModels.Settings;
using App.DomainServices.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.identity
{
    public static class CustomTicketStoreExtensions
    {
        public static IServiceCollection AddCustomTicketStore(
            this IServiceCollection services, SiteSettings siteSettings)
        {
            // To manage large identity cookies
            var cookieOptions = siteSettings.CookieOptions;
            if (cookieOptions.UseDistributedCacheTicketStore)
            {
                services.AddDistributedSqlServerCache(options =>
                {
                    var cacheOptions = cookieOptions.DistributedSqlServerCacheOptions;

                    var connectionString = string.IsNullOrWhiteSpace(cacheOptions.ConnectionString) ?
                            siteSettings.GetDbConnectionString() :
                            cacheOptions.ConnectionString;
                    options.ConnectionString = connectionString;

                    options.SchemaName = cacheOptions.SchemaName;

                    options.TableName = cacheOptions.TableName;
                });
                services.AddScoped<ITicketStore, DistributedCacheTicketStore>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
            }

            return services;
        }
    }
}