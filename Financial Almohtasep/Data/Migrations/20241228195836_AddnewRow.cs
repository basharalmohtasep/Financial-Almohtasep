using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class AddnewRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceChange",
                table: "ClinetsTransaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceChange",
                table: "ClinetsTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
