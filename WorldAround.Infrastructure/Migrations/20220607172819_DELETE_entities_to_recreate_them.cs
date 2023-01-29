using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class DELETE_entities_to_recreate_them : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Events_EventId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "ParticipantRolePermissionLinks");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "TripEventLinks");

            migrationBuilder.DropTable(
                name: "ParticipantsPermissions");

            migrationBuilder.DropTable(
                name: "ParticipantRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_EventId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantsPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripsion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantsPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripEventLinks",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEventLinks", x => new { x.TripId, x.EventId });
                    table.ForeignKey(
                        name: "FK_TripEventLinks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripEventLinks_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ParticipantRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Participants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_ParticipantRoles_ParticipantRoleId",
                        column: x => x.ParticipantRoleId,
                        principalTable: "ParticipantRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantRolePermissionLinks",
                columns: table => new
                {
                    ParticipantPermissionId = table.Column<int>(type: "int", nullable: false),
                    ParticipantRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantRolePermissionLinks", x => new { x.ParticipantPermissionId, x.ParticipantRoleId });
                    table.ForeignKey(
                        name: "FK_ParticipantRolePermissionLinks_ParticipantRoles_ParticipantPermissionId",
                        column: x => x.ParticipantPermissionId,
                        principalTable: "ParticipantRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantRolePermissionLinks_ParticipantsPermissions_ParticipantPermissionId",
                        column: x => x.ParticipantPermissionId,
                        principalTable: "ParticipantsPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_EventId",
                table: "Ratings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                table: "Comments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventId",
                table: "Participants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantRoleId",
                table: "Participants",
                column: "ParticipantRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEventLinks_EventId",
                table: "TripEventLinks",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Events_EventId",
                table: "Ratings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
