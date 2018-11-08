using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Sql.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId1",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId1",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUsedPassword_AspNetUsers_UserId",
                table: "UserUsedPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUsedPassword",
                table: "UserUsedPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserTokens_UserId1",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_UserId1",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "UserUsedPassword",
                newName: "AppUserUsedPasswords");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AppUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AppUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AppUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AppUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AppRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AppRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserUsedPassword_UserId",
                table: "AppUserUsedPasswords",
                newName: "IX_AppUserUsedPasswords_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppUserTokens",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppUserRoles",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "RoleId1",
                table: "AppUserRoles",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AppUserRoles",
                newName: "IX_AppUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppUserLogins",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AppUserLogins",
                newName: "IX_AppUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppUserClaims",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AppUserClaims",
                newName: "IX_AppUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "RoleId1",
                table: "AppRoleClaims",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AppRoleClaims",
                newName: "IX_AppRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "HashedPassword",
                table: "AppUserUsedPasswords",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUserUsedPasswords",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUserUsedPasswords",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppUserUsedPasswords",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppUserUsedPasswords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUserUsedPasswords",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUserUsedPasswords",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "AppUserUsedPasswords",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUserUsedPasswords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUserTokens",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUserTokens",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUserTokens",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUserTokens",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUsers",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUsers",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUserRoles",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUserRoles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUserRoles",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUserRoles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUserLogins",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUserLogins",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUserLogins",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUserLogins",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppUserClaims",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppUserClaims",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppUserClaims",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppUserClaims",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppRoles",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppRoles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppRoles",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppRoles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "AppRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowserName",
                table: "AppRoleClaims",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "AppRoleClaims",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "AppRoleClaims",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "AppRoleClaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByBrowserName",
                table: "AppRoleClaims",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByIp",
                table: "AppRoleClaims",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDateTime",
                table: "AppRoleClaims",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserUsedPasswords",
                table: "AppUserUsedPasswords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserTokens",
                table: "AppUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoles",
                table: "AppRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppDataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendlyName = table.Column<string>(nullable: true),
                    XmlData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSqlCache",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 449, nullable: false),
                    Value = table.Column<byte[]>(nullable: false),
                    ExpiresAtTime = table.Column<DateTimeOffset>(nullable: false),
                    SlidingExpirationInSeconds = table.Column<long>(nullable: true),
                    AbsoluteExpiration = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSqlCache", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDataProtectionKeys_FriendlyName",
                table: "AppDataProtectionKeys",
                column: "FriendlyName",
                unique: true,
                filter: "[FriendlyName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Index_ExpiresAtTime",
                schema: "dbo",
                table: "AppSqlCache",
                column: "ExpiresAtTime");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleClaims_AppRoles_RoleId",
                table: "AppRoleClaims",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserClaims_AppUsers_UserId",
                table: "AppUserClaims",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLogins_AppUsers_UserId",
                table: "AppUserLogins",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppUsers_UserId",
                table: "AppUserRoles",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTokens_AppUsers_UserId",
                table: "AppUserTokens",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserUsedPasswords_AppUsers_UserId",
                table: "AppUserUsedPasswords",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleClaims_AppRoles_RoleId",
                table: "AppRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserClaims_AppUsers_UserId",
                table: "AppUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserLogins_AppUsers_UserId",
                table: "AppUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AppRoles_RoleId",
                table: "AppUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AppUsers_UserId",
                table: "AppUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTokens_AppUsers_UserId",
                table: "AppUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserUsedPasswords_AppUsers_UserId",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropTable(
                name: "AppDataProtectionKeys");

            migrationBuilder.DropTable(
                name: "AppSqlCache",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserUsedPasswords",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserTokens",
                table: "AppUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoles",
                table: "AppRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUserUsedPasswords");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppUserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowserName",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByBrowserName",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByIp",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AppRoleClaims");

            migrationBuilder.RenameTable(
                name: "AppUserUsedPasswords",
                newName: "UserUsedPassword");

            migrationBuilder.RenameTable(
                name: "AppUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AppUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AppUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AppUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AppRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AppRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserUsedPasswords_UserId",
                table: "UserUsedPassword",
                newName: "IX_UserUsedPassword_UserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "AspNetUserTokens",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "AspNetUserRoles",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "AspNetUserRoles",
                newName: "RoleId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "AspNetUserLogins",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "AspNetUserClaims",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "AspNetRoleClaims",
                newName: "RoleId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "HashedPassword",
                table: "UserUsedPassword",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUsedPassword",
                table: "UserUsedPassword",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserId1",
                table: "AspNetUserTokens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId1",
                table: "AspNetUserTokens",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUsedPassword_AspNetUsers_UserId",
                table: "UserUsedPassword",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
