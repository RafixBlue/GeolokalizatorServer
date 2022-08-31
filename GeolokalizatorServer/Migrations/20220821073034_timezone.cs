using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeolokalizatorServer.Migrations
{
    public partial class timezone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDateTime",
                table: "Synchronizations");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Synchronizations",
                newName: "LastSynchronization");

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDatas_UserID",
                table: "UserDatas",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatas_Users_UserID",
                table: "UserDatas",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDatas_Users_UserID",
                table: "UserDatas");

            migrationBuilder.DropIndex(
                name: "IX_UserDatas_UserID",
                table: "UserDatas");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "LastSynchronization",
                table: "Synchronizations",
                newName: "StartDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDateTime",
                table: "Synchronizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
