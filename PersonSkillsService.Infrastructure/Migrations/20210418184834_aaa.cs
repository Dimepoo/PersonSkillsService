using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSkillsService.Infrastructure.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Level", "Name", "PersonId" },
                values: new object[] { 4L, (byte)12, "Ловкость", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
