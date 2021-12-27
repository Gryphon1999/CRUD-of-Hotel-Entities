using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebSystem.Migrations
{
    public partial class AddPostStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostStatus",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostStatus",
                table: "orders");
        }
    }
}
