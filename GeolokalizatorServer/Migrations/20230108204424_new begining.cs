using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolokalizatorServer.Migrations
{
    public partial class newbegining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "RSSNR",
                table: "Signals",
                newName: "Rssnr");

            migrationBuilder.RenameColumn(
                name: "RSSI",
                table: "Signals",
                newName: "Rssi");

            migrationBuilder.RenameColumn(
                name: "RSRQ",
                table: "Signals",
                newName: "Rsrq");

            migrationBuilder.RenameColumn(
                name: "RSRP",
                table: "Signals",
                newName: "Rsrp");

            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "Locations",
                newName: "SpeedAccuracy");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MeasurementTime",
                table: "UserDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Asu",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bandwidth",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Earfcn",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ta",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tac",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementTime",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "Asu",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "Bandwidth",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "Earfcn",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "Ta",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "Tac",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Rssnr",
                table: "Signals",
                newName: "RSSNR");

            migrationBuilder.RenameColumn(
                name: "Rssi",
                table: "Signals",
                newName: "RSSI");

            migrationBuilder.RenameColumn(
                name: "Rsrq",
                table: "Signals",
                newName: "RSRQ");

            migrationBuilder.RenameColumn(
                name: "Rsrp",
                table: "Signals",
                newName: "RSRP");

            migrationBuilder.RenameColumn(
                name: "SpeedAccuracy",
                table: "Locations",
                newName: "TimeZone");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
