using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Sql.Migrations
{
    public partial class Update_Slider_Title_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Slider",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Slider",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Slider",
                newName: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Slider",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
