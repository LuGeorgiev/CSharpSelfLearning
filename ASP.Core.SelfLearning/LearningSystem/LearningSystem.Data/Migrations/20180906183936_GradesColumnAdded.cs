using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Migrations
{
    public partial class GradesColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TrainerId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "StudentCourse",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TrainerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentCourse");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
