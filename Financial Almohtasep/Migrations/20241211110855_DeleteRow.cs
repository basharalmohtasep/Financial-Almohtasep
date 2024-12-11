using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeNetSalaries");

            migrationBuilder.DropColumn(
                name: "NetSalaryId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NetSalaryId",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmployeeNetSalaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NetSalary = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNetSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeNetSalaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeNetSalaries_EmployeeId",
                table: "EmployeeNetSalaries",
                column: "EmployeeId",
                unique: true);
        }
    }
}
