using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Data.Migrations
{
    public partial class SpecTaskAnswerScoreRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialTaskAnswerScores");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "SpecialTaskAnswers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreResult",
                table: "SpecialTaskAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "SpecialTaskAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "SpecialTaskAnswers");

            migrationBuilder.DropColumn(
                name: "ScoreResult",
                table: "SpecialTaskAnswers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SpecialTaskAnswers");

            migrationBuilder.CreateTable(
                name: "SpecialTaskAnswerScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreResult = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaskAnswerScores", x => x.Id);
                });
        }
    }
}
