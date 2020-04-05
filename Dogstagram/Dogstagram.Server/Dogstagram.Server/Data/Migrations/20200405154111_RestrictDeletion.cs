using Microsoft.EntityFrameworkCore.Migrations;

namespace Dogstagram.Server.Data.Migrations
{
    public partial class RestrictDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
