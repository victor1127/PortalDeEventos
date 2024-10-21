using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalDeEventos.data.migrations
{
    /// <inheritdoc />
    public partial class updateToEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AuthorId",
                table: "Events",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_AuthorId",
                table: "Events",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AuthorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AuthorId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Events");

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedById",
                table: "Events",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatedById",
                table: "Events",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
