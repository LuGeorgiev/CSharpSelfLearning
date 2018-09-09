﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LearningSystem.Data.Migrations
{
    public partial class FileSizeIncrease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ExamSubmission",
                table: "StudentCourse",
                maxLength: 2097152,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2048,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ExamSubmission",
                table: "StudentCourse",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2097152,
                oldNullable: true);
        }
    }
}
