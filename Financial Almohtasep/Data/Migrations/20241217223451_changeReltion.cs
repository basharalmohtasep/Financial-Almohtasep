using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class changeReltion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payees_ChequeDetails_ChequeDetailsId",
                table: "Payees");

            migrationBuilder.DropIndex(
                name: "IX_Payees_ChequeDetailsId",
                table: "Payees");

            migrationBuilder.DropColumn(
                name: "ChequeDetailsId",
                table: "Payees");

            migrationBuilder.DropColumn(
                name: "ChequeId",
                table: "Payees");

            migrationBuilder.AddColumn<Guid>(
                name: "PayeeId",
                table: "ChequeDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "payeesId",
                table: "ChequeDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChequeDetails_payeesId",
                table: "ChequeDetails",
                column: "payeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChequeDetails_Payees_payeesId",
                table: "ChequeDetails",
                column: "payeesId",
                principalTable: "Payees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChequeDetails_Payees_payeesId",
                table: "ChequeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ChequeDetails_payeesId",
                table: "ChequeDetails");

            migrationBuilder.DropColumn(
                name: "PayeeId",
                table: "ChequeDetails");

            migrationBuilder.DropColumn(
                name: "payeesId",
                table: "ChequeDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ChequeDetailsId",
                table: "Payees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChequeId",
                table: "Payees",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payees_ChequeDetailsId",
                table: "Payees",
                column: "ChequeDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payees_ChequeDetails_ChequeDetailsId",
                table: "Payees",
                column: "ChequeDetailsId",
                principalTable: "ChequeDetails",
                principalColumn: "Id");
        }
    }
}
