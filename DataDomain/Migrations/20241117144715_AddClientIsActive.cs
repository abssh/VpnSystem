﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Clients");
        }
    }
}
