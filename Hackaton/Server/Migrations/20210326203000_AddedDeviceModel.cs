using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton.Server.Migrations
{
    public partial class AddedDeviceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "Information");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Information",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longtitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Information_DeviceId",
                table: "Information",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Devices_DeviceId",
                table: "Information",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Devices_DeviceId",
                table: "Information");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Information_DeviceId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Information");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
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

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Information",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longtitude",
                table: "Information",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}