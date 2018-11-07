using App.Bootstraper.identity;
using App.Bootstraper.Mapping;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Identity;
using App.DomainModels.ViewModels.Settings;
using App.DomainServices.Identity;
using App.DomainServices.Identity.Contracts;
using App.DomainServices.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            #region اضافی
            //services.AddScoped<IUnitOfWork, AppDbContext>();
            //services.AddScoped<IApplicationUserStore, ApplicationUserStore>();
            //services.AddScoped<UserStore<User, Role, AppDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, ApplicationUserStore>();

            //services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
            //services.AddScoped<UserManager<User>, ApplicationUserManager>();

            //services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
            //services.AddScoped<RoleManager<Role>, ApplicationRoleManager>();

            //services.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();
            //services.AddScoped<SignInManager<User>, ApplicationSignInManager>();

            //services.AddScoped<IApplicationRoleStore, ApplicationRoleStore>();
            //services.AddScoped<RoleStore<Role, AppDbContext, int, UserRole, RoleClaim>, ApplicationRoleStore>();

            //services.AddIdentity<User, Role>(identityOptions =>
            //{
            //}).AddUserStore<ApplicationUserStore>()
            //  .AddUserManager<ApplicationUserManager>()
            //  .AddRoleStore<ApplicationRoleStore>()
            //  .AddRoleManager<ApplicationRoleManager>()
            //  .AddSignInManager<ApplicationSignInManager>()
            //  // You **cannot** use .AddEntityFrameworkStores() when you customize everything
            //  //.AddEntityFrameworkStores<ApplicationDbContext, int>()
            //  .AddDefaultTokenProviders(); 
            #endregion


            services.AddTransient<IMessagesService, MessagesService>();
            services.AddTransient<PersonRepository>();
            services.Configure<SiteSettings>(options => configuration.Bind(options));

            #region Identity
            services.AddCustomIdentityServices();
            //services.AddScoped<IUserClaimsPrincipalFactory<User>, ApplicationClaimsPrincipalFactory>();
            //services.AddScoped<UserClaimsPrincipalFactory<User, Role>, ApplicationClaimsPrincipalFactory>();

            //services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();


            #endregion


            //تزریق تمام repository ها با استفاده از reflection که از فضای نام آن ها استفاده میکند
            // Domain Services
            services.Scan(scan =>
                scan.FromAssemblyOf<PersonRepository>()
                    .AddClasses(classes => classes.InNamespaceOf<PersonRepository>())
                    .AsSelf()
                    .WithScopedLifetime());

            //بایند کردن موجودیت ConnectionStrings از appsetting به Model  مورد نظر
            services.Configure<ConnectionString>(options => configuration.GetSection("ConnectionStrings").Bind(options));
            services.AddScoped<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("ConnectionStrings")));

            //اتصال connectionStrings به AppDbContext
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));

            services.AddAutoMapper(typeof(PersonProfile));


        }
    }
}
