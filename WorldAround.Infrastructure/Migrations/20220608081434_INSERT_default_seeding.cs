using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class INSERT_default_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessibilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Public" },
                    { 2, "Private" }
                });

            migrationBuilder.InsertData(
                table: "ParticipantRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Admin" },
                    { 3, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessibilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accessibilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParticipantRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParticipantRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParticipantRoles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
