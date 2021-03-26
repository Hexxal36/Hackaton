using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton.Server.Migrations
{
    public partial class ReDo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Devices_DeviceID",
                table: "Information");

            migrationBuilder.RenameColumn(
                name: "DeviceID",
                table: "Information",
                newName: "DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Information_DeviceID",
                table: "Information",
                newName: "IX_Information_DeviceId");

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

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "Information",
                newName: "DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_Information_DeviceId",
                table: "Information",
                newName: "IX_Information_DeviceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Devices_DeviceID",
                table: "Information",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
