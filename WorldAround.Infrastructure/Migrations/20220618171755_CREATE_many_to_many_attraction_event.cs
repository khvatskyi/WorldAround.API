using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldAround.Infrastructure.Migrations
{
    public partial class CREATE_many_to_many_attraction_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttractionEventLinks",
                columns: table => new
                {
                    AttractionId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionEventLinks", x => new { x.AttractionId, x.EventId });
                    table.ForeignKey(
                        name: "FK_AttractionEventLinks_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionEventLinks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractionEventLinks_EventId",
                table: "AttractionEventLinks",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionEventLinks");
        }
    }
}
