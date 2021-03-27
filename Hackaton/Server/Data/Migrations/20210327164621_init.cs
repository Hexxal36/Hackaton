using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton.Server.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaterQuality",
                table: "Information");

            migrationBuilder.AddColumn<string>(
                name: "DissolvedOxygen",
                table: "Information",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Information",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ORP",
                table: "Information",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PH",
                table: "Information",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Longtitude",
                table: "Devices",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Devices",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DissolvedOxygen",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "ORP",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "PH",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "WaterQuality",
                table: "Information",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Longtitude",
                table: "Devices",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "Devices",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
