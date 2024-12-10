﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    /// <inheritdoc />
    public partial class addnewRowToEmplooy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");
        }
    }
}
