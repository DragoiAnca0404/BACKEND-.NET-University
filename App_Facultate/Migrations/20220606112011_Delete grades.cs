using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Deletegrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Calificative",
                columns: new[] { "id_Calificativ", "Materiiid_materie", "Studentiid_student", "id_materie", "id_student", "nota" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, 10.0 },
                    { 2, null, null, 2, 2, 9.0500000000000007 },
                    { 3, null, null, 2, 3, 8.5500000000000007 },
                    { 4, null, null, 1, 3, 10.0 },
                    { 5, null, null, 2, 4, 5.0 }
                });
        }
    }
}
