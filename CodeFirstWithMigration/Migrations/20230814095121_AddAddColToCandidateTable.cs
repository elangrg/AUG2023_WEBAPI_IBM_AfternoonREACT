﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstWithMigration.Migrations
{
    public partial class AddAddColToCandidateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Candidates");
        }
    }
}
