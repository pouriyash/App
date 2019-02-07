using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Sql.Migrations
{
    public partial class Update_Info_OurStory_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OurStory",
                table: "Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OurStory",
                table: "Info");
        }
    }
}
