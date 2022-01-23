using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebSystem.Migrations
{
    public partial class MenuImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "menus",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "menus");
        }
    }
}
