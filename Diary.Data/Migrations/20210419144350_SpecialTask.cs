using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Data.Migrations
{
    public partial class SpecialTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialTaskAnswerFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecialTaskAnswerId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaskAnswerFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTaskAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecialTaskId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaskAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTaskAnswerScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScoreResult = table.Column<int>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaskAnswerScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTaskFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    SpecialTaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaskFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SpecialTaskType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialTaskAnswerFiles");

            migrationBuilder.DropTable(
                name: "SpecialTaskAnswers");

            migrationBuilder.DropTable(
                name: "SpecialTaskAnswerScores");

            migrationBuilder.DropTable(
                name: "SpecialTaskFiles");

            migrationBuilder.DropTable(
                name: "SpecialTasks");
        }
    }
}
