﻿// <auto-generated />
using System;
using App.Data.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Data.Sql.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.DomainModels.Entities.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.AppDataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendlyName");

                    b.Property<string>("XmlData");

                    b.HasKey("Id");

                    b.HasIndex("FriendlyName")
                        .IsUnique()
                        .HasFilter("[FriendlyName] IS NOT NULL");

                    b.ToTable("AppDataProtectionKeys");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.AppSqlCache", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(449);

                    b.Property<DateTimeOffset?>("AbsoluteExpiration");

                    b.Property<DateTimeOffset>("ExpiresAtTime");

                    b.Property<long?>("SlidingExpirationInSeconds");

                    b.Property<byte[]>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAtTime")
                        .HasName("Index_ExpiresAtTime");

                    b.ToTable("AppSqlCache","dbo");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTimeOffset?>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(450);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsEmailPublic");

                    b.Property<string>("LastName")
                        .HasMaxLength(450);

                    b.Property<DateTimeOffset?>("LastVisitDateTime");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhotoFileName")
                        .HasMaxLength(450);

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserUsedPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("CreatedByUserId");

                    b.Property<DateTimeOffset?>("CreatedDateTime");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("ModifiedByBrowserName")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedByIp")
                        .HasMaxLength(255);

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<DateTimeOffset?>("ModifiedDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserUsedPasswords");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int?>("ProductTypeId");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColor");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.ProductGalleryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductGalleryImage");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DomainModels.Entities.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Identity.UserUsedPassword", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Identity.User", "User")
                        .WithMany("UserUsedPasswords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.Product", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Products.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.ProductColor", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Products.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("App.DomainModels.Entities.Products.ProductGalleryImage", b =>
                {
                    b.HasOne("App.DomainModels.Entities.Products.Product", "Product")
                        .WithMany("ProductGalleryImages")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
