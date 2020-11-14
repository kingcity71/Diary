using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Data.Migrations
{
    public partial class ScoresAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScoreResult = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
