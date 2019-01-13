using App.DomainModels.Entities.Identity;
using App.DomainModels.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using App.Common.Extentions.Persian;
using App.DomainModels.Entities.AuditableEntity;
using App.Common.GuardToolkit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using App.DomainModels.ViewModels.Settings;
using App.Data.Sql.Mapping;
using App.DomainModels.Entities.Products;
using App.DomainModels.Entities;
using App.DomainModels.Entities.Blogs;

namespace App.Data.Sql.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region BaseClass

        //public virtual DbSet<AppLogItem> AppLogItems { get; set; }
        //public virtual DbSet<AppSqlCache> AppSqlCache { get; set; }
        //public virtual DbSet<AppDataProtectionKey> AppDataProtectionKeys { get; set; }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().AddRange(entities);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Add(entity);
        }

        public void ExecuteSqlCommand(string query)
        {
            Database.ExecuteSqlCommand(query);
        }

        public void ExecuteSqlCommand(string query, params object[] parameters)
        {
            Database.ExecuteSqlCommand(query, parameters);
        }

        public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
        {
            var value = this.Entry(entity).Property(propertyName).CurrentValue;
            return value != null
                ? (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)
                : default(T);
        }

        public object GetShadowPropertyValue(object entity, string propertyName)
        {
            return this.Entry(entity).Property(propertyName).CurrentValue;
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Update(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.DetectChanges();

            beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        //Todo Cmpelete
        private void beforeSaveTriggers()
        {
            //validateEntities();
            setShadowProperties();
            this.ApplyCorrectYeKe();
        }

        //Todo Compelete
        private void setShadowProperties()
        {
            // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            httpContextAccessor.CheckArgumentIsNull(nameof(httpContextAccessor));
            ChangeTracker.SetAuditableEntityPropertyValues(httpContextAccessor);
        }

        //Todo Impelement
        //از رفیعی پرسیده شود
        private void validateEntities()
        {
            //var errors = this.GetValidationErrors();
            //if (!string.IsNullOrWhiteSpace(errors))
            //{
            //    // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
            //    var loggerFactory = this.GetService<ILoggerFactory>();
            //    loggerFactory.CheckArgumentIsNull(nameof(loggerFactory));
            //    var logger = loggerFactory.CreateLogger<AppDbContext>();
            //    logger.LogError(errors);
            //    throw new InvalidOperationException(errors);
            //}
        }

        #endregion

        #region DbSets

        /// <summary>
        /// جدول کاربر تست
        /// </summary>
        public DbSet<Person> Person { get; set; }

        /// <summary>
        /// جدول نوع محصولات
        /// </summary>
        public DbSet<ProductType> ProductType { get; set; }

        /// <summary>
        /// جدول محصولات
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        ///رنگ محصول
        /// </summary>
        public DbSet<ProductColor> ProductColor { get; set; }

        /// <summary>
        /// گالری محصولات
        /// </summary>
        public DbSet<ProductGalleryImage> ProductGalleryImage { get; set; }

        /// <summary>
        /// ارتباط با ما
        /// </summary>
        public DbSet<ContactUs> ContactUs { get; set; }


        /// <summary>
        /// اسلایدر
        /// </summary>
        public DbSet<Slider> Slider { get; set; }

        /// <summary>
        /// بلاگ ها
        /// </summary>
        public DbSet<Blogs> Blogs { get; set; }


        /// <summary>
        /// گالری بلاگ
        /// </summary>
        public DbSet<BlogsGallery> BlogsGallery { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);
            // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
            var siteSettings = this.GetService<IOptionsSnapshot<SiteSettings>>();
            siteSettings.CheckArgumentIsNull(nameof(siteSettings));
            siteSettings.Value.CheckArgumentIsNull(nameof(siteSettings.Value));
            // Adds all of the ASP.NET Core Identity related mappings at once.
            builder.AddCustomIdentityMappings(siteSettings.Value);

            //builder.Entity<Product>(build =>
            //{
            //    build.Property(product => product.Name).HasMaxLength(450).IsRequired();
            //    build.HasOne(product => product.Category)
            //           .WithMany(category => category.Products);
            //});

            // This should be placed here, at the end.
            builder.AddAuditableShadowProperties();
        }

    }
}
