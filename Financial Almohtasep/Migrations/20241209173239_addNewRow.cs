using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class addNewRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "NetSalary",
                table: "EmployeeTransaction",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "EmployeeTransaction");
        }
    }
}
