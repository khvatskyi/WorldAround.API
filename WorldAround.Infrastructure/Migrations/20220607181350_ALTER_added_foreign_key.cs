using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class ALTER_added_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TripId",
                table: "Albums",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Trips_TripId",
                table: "Albums",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Trips_TripId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TripId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Albums");
        }
    }
}
