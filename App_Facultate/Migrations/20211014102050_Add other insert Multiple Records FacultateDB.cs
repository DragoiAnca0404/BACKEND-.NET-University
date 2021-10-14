using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class AddotherinsertMultipleRecordsFacultateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 1,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 1, 1, 5000m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 2,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 2, 2, 5800m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 3,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 3, 3, 7830m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 4,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 4, 4, 4000m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 5,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 5, 5, 6700m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 1,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 0, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 2,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 0, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 3,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 0, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 4,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 0, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 5,
                columns: new[] { "id_materie", "id_utilizator", "salariu" },
                values: new object[] { 0, 0, 0m });
        }
    }
}
