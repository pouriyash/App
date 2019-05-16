using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Sql.Migrations
{
    public partial class Update_ProductType_Parent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ParentId",
                table: "ProductType",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_ProductType_ParentId",
                table: "ProductType",
                column: "ParentId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_ProductType_ParentId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ParentId",
                table: "ProductType");
        }
    }
}
