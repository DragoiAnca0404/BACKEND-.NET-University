using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comands",
                table: "Comands");

            migrationBuilder.RenameTable(
                name: "Comands",
                newName: "Specializare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializare",
                table: "Specializare",
                column: "id_Specializare");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scutit_plata = table.Column<bool>(type: "bit", nullable: false),
                    id_specializare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id_student);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializare",
                table: "Specializare");

            migrationBuilder.RenameTable(
                name: "Specializare",
                newName: "Comands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comands",
                table: "Comands",
                column: "id_Specializare");
        }
    }
}
