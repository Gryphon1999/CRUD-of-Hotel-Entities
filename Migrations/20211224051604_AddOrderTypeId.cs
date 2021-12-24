using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebSystem.Migrations
{
    public partial class AddOrderTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderTypeId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTypeId",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
