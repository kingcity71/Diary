using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Data.Migrations
{
    public partial class PropertyValuesColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertieValues",
                table: "PropertieValues");

            migrationBuilder.RenameTable(
                name: "PropertieValues",
                newName: "PropertyValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyValues",
                table: "PropertyValues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyValues",
                table: "PropertyValues");

            migrationBuilder.RenameTable(
                name: "PropertyValues",
                newName: "PropertieValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertieValues",
                table: "PropertieValues",
                column: "Id");
        }
    }
}
