using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalDeEventos.data.migrations
{
    /// <inheritdoc />
    public partial class tablesupdatedeventsandeventregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration_AspNetUsers_EventUserId",
                table: "EventRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration_Events_EventId",
                table: "EventRegistration");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistration_EventId",
                table: "EventRegistration");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EventUserId",
                table: "EventRegistration",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "EventRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedById",
                table: "Events",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventsId",
                table: "EventRegistration",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration_AspNetUsers_EventUserId",
                table: "EventRegistration",
                column: "EventUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration_Events_EventsId",
                table: "EventRegistration",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatedById",
                table: "Events",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration_AspNetUsers_EventUserId",
                table: "EventRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistration_Events_EventsId",
                table: "EventRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistration_EventsId",
                table: "EventRegistration");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "EventRegistration");

            migrationBuilder.AlterColumn<string>(
                name: "EventUserId",
                table: "EventRegistration",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "EventUserEvents",
                columns: table => new
                {
                    EventUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserEvents", x => new { x.EventUsersId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventUserEvents_AspNetUsers_EventUsersId",
                        column: x => x.EventUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUserEvents_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventId",
                table: "EventRegistration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserEvents_EventsId",
                table: "EventUserEvents",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration_AspNetUsers_EventUserId",
                table: "EventRegistration",
                column: "EventUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistration_Events_EventId",
                table: "EventRegistration",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
