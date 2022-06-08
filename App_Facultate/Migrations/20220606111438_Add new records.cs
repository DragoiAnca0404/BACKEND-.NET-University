using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Addnewrecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 1,
                column: "id_student",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 2,
                column: "id_student",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 3,
                column: "id_student",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 4,
                column: "id_student",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 5,
                column: "id_student",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 1,
                column: "id_student",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 2,
                column: "id_student",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 3,
                column: "id_student",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 4,
                column: "id_student",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 5,
                column: "id_student",
                value: 0);
        }
    }
}
