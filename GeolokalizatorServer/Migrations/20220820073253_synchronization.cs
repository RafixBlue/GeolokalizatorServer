using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolokalizatorServer.Migrations
{
    public partial class synchronization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Synchronizations");

            migrationBuilder.RenameColumn(
                name: "LastSynchronisationTime",
                table: "Synchronizations",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "FirstSynchronisation",
                table: "Synchronizations",
                newName: "FinishDateTime");

            migrationBuilder.AddColumn<int>(
                name: "DeviceNumber",
                table: "Synchronizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "Synchronizations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceNumber",
                table: "Synchronizations");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "Synchronizations");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Synchronizations",
                newName: "LastSynchronisationTime");

            migrationBuilder.RenameColumn(
                name: "FinishDateTime",
                table: "Synchronizations",
                newName: "FirstSynchronisation");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Synchronizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
