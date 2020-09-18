using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CreateIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionId_Name",
                table: "Positions",
                columns: new[] { "PositionId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId_Name",
                table: "Employees",
                columns: new[] { "EmployeeId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId_Name",
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Positions_PositionId_Name",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId_Name",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentId_Name",
                table: "Departments");
        }
    }
}
