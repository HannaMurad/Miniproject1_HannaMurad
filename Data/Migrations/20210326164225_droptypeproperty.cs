using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class droptypeproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Assets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
