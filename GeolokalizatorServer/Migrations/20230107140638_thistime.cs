using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolokalizatorServer.Migrations
{
    public partial class thistime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceNumber",
                table: "Synchronizations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSynchronization",
                table: "Synchronizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSynchronization",
                table: "Synchronizations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeviceNumber",
                table: "Synchronizations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
