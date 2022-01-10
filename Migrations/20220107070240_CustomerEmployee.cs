using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebSystem.Migrations
{
    public partial class CustomerEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_customers_CustomerId",
                table: "CustomerEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_employees_EmployeeId",
                table: "CustomerEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerEmployee",
                table: "CustomerEmployee");

            migrationBuilder.RenameTable(
                name: "CustomerEmployee",
                newName: "customerEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerEmployee_EmployeeId",
                table: "customerEmployees",
                newName: "IX_customerEmployees_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerEmployees",
                table: "customerEmployees",
                columns: new[] { "CustomerId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_customerEmployees_customers_CustomerId",
                table: "customerEmployees",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customerEmployees_employees_EmployeeId",
                table: "customerEmployees",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerEmployees_customers_CustomerId",
                table: "customerEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_customerEmployees_employees_EmployeeId",
                table: "customerEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customerEmployees",
                table: "customerEmployees");

            migrationBuilder.RenameTable(
                name: "customerEmployees",
                newName: "CustomerEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_customerEmployees_EmployeeId",
                table: "CustomerEmployee",
                newName: "IX_CustomerEmployee_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerEmployee",
                table: "CustomerEmployee",
                columns: new[] { "CustomerId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_customers_CustomerId",
                table: "CustomerEmployee",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_employees_EmployeeId",
                table: "CustomerEmployee",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
