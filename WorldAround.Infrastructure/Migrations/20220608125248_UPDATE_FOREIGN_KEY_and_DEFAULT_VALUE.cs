using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class UPDATE_FOREIGN_KEY_and_DEFAULT_VALUE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Accessibilities_AccessibilityId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AccessibilityId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Accessibilities_AccessibilityId",
                table: "Events",
                column: "AccessibilityId",
                principalTable: "Accessibilities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Accessibilities_AccessibilityId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<int>(
                name: "AccessibilityId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Accessibilities_AccessibilityId",
                table: "Events",
                column: "AccessibilityId",
                principalTable: "Accessibilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
