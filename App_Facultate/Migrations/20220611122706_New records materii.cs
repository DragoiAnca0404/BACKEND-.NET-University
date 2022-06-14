using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Newrecordsmaterii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "Studentiid_student", "denumire_materie", "id_student" },
                values: new object[] { 6, null, "Psihologie politica", 3 });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "Studentiid_student", "denumire_materie", "id_student" },
                values: new object[] { 7, null, "Psihologie politica", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 7);
        }
    }
}
