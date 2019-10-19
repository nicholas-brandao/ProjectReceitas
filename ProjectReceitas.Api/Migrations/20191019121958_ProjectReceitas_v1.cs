using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectReceitas.Api.Migrations
{
    public partial class ProjectReceitas_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "Nicholas", "Nicholas", "123" },
                    { 2, "Andre", "Andre", "123" },
                    { 3, "Wallace", "Wallace", "123" },
                    { 4, "Moraes", "Moraes", "123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
