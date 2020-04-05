using Microsoft.EntityFrameworkCore.Migrations;

namespace Dogstagram.Server.Data.Migrations
{
    public partial class DogsForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_AspNetUsers_UserId",
                table: "Dog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dog",
                table: "Dog");

            migrationBuilder.RenameTable(
                name: "Dog",
                newName: "Dogs");

            migrationBuilder.RenameIndex(
                name: "IX_Dog_UserId",
                table: "Dogs",
                newName: "IX_Dogs_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Dogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dogs",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_AspNetUsers_UserId",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "Dog");

            migrationBuilder.RenameIndex(
                name: "IX_Dogs_UserId",
                table: "Dog",
                newName: "IX_Dog_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dog",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dog",
                table: "Dog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_AspNetUsers_UserId",
                table: "Dog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
