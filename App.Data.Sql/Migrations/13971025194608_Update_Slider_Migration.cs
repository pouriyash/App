using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Sql.Migrations
{
    public partial class Update_Slider_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Slider",
                newName: "Subject");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Slider",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Slider");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Slider",
                newName: "Description");
        }
    }
}
