using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton.Server.Migrations
{
    public partial class AddedDateTimeSpans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfModifications",
                table: "Information",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Information",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Information",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Information");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Information",
                newName: "DateOfModifications");
        }
    }
}
