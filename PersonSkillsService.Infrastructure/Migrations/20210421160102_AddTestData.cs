using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSkillsService.Infrastructure.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { 1L, "Виталий", "Виталий" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { 2L, "Евгений", "Евгений" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { 3L, "Екатерина", "Екатерина" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Level", "Name", "PersonId" },
                values: new object[,]
                {
                    { 1L, (byte)10, "Сила", 1L },
                    { 4L, (byte)12, "Ловкость", 1L },
                    { 2L, (byte)15, "Ум", 2L },
                    { 3L, (byte)10, "Хитрость", 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
