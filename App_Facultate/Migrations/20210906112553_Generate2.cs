using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Generate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_materie",
                table: "Calificative");

            migrationBuilder.DropColumn(
                name: "id_student",
                table: "Calificative");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_materie",
                table: "Calificative",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_student",
                table: "Calificative",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
