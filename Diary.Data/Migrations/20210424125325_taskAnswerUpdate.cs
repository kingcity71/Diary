using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Data.Migrations
{
    public partial class taskAnswerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "SpecialTaskAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "SpecialTaskAnswers");
        }
    }
}
