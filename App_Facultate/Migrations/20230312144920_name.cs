using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentDateGrade",
                table: "Calificative",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 1,
                column: "CurrentDateGrade",
                value: "10-12-2023");

            migrationBuilder.UpdateData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 2,
                column: "CurrentDateGrade",
                value: "10-12-2023");

            migrationBuilder.UpdateData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 3,
                column: "CurrentDateGrade",
                value: "10-12-2023");

            migrationBuilder.UpdateData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 4,
                column: "CurrentDateGrade",
                value: "10-12-2023");

            migrationBuilder.UpdateData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 5,
                column: "CurrentDateGrade",
                value: "10-12-2023");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDateGrade",
                table: "Calificative");
        }
    }
}
