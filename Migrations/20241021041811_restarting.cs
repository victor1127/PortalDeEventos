using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalDeEventos.Migrations
{
    /// <inheritdoc />
    public partial class restarting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "EventRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRegistration_AspNetUsers_EventUserId",
                        column: x => x.EventUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRegistration_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventId",
                table: "EventRegistration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventUserId",
                table: "EventRegistration",
                column: "EventUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "EventRegistration");

        }
    }
}
