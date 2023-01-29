using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class ALTER_USERS_add_image_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Images",
                newName: "ImagePath");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Images",
                newName: "FilePath");
        }
    }
}
