using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Teste_Codificar.Migrations
{
    /// <inheritdoc />
    public partial class SeedResponsaveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Responsaveis",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "João Silva" },
                    { 2, "Maria Santos" },
                    { 3, "Carlos Oliveira" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responsaveis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responsaveis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responsaveis",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
