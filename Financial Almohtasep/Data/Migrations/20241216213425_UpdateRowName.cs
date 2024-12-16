using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRowName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelationshipType",
                table: "Payees",
                newName: "PayeeTypes");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "ChequeDetails",
                newName: "currency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayeeTypes",
                table: "Payees",
                newName: "RelationshipType");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "ChequeDetails",
                newName: "Currency");
        }
    }
}
