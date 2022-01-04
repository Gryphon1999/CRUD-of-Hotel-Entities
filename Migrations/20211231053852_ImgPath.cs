using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebSystem.Migrations
{
    public partial class ImgPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderTypeId",
                table: "orders",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_assigns_CustomerId",
                table: "assigns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_assigns_EmployeeId",
                table: "assigns",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_assigns_customers_CustomerId",
                table: "assigns",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assigns_employees_EmployeeId",
                table: "assigns",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orderTypes_OrderTypeId",
                table: "orders",
                column: "OrderTypeId",
                principalTable: "orderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigns_customers_CustomerId",
                table: "assigns");

            migrationBuilder.DropForeignKey(
                name: "FK_assigns_employees_EmployeeId",
                table: "assigns");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_orderTypes_OrderTypeId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_OrderTypeId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_assigns_CustomerId",
                table: "assigns");

            migrationBuilder.DropIndex(
                name: "IX_assigns_EmployeeId",
                table: "assigns");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "employees");
        }
    }
}
