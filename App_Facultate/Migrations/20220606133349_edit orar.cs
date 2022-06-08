using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class editorar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orar_start",
                table: "Orar",
                newName: "Time_start");

            migrationBuilder.RenameColumn(
                name: "orar_sfarsit",
                table: "Orar",
                newName: "Time_end");

            migrationBuilder.AlterColumn<int>(
                name: "ziua",
                table: "Orar",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time_start",
                table: "Orar",
                newName: "orar_start");

            migrationBuilder.RenameColumn(
                name: "Time_end",
                table: "Orar",
                newName: "orar_sfarsit");

            migrationBuilder.AlterColumn<string>(
                name: "ziua",
                table: "Orar",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
