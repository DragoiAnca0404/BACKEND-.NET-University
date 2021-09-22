using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class AddSchemaDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    id_materie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_materie = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.id_materie);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    id_utilizator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    parola = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.id_utilizator);
                });

            migrationBuilder.CreateTable(
                name: "Calificativ",
                columns: table => new
                {
                    id_Specializare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<int>(type: "int", nullable: false),
                    id_materie = table.Column<int>(type: "int", nullable: false),
                    Materiiid_materie = table.Column<int>(type: "int", nullable: true),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    Studentiid_student = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificativ", x => x.id_Specializare);
                    table.ForeignKey(
                        name: "FK_Calificativ_Materie_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materie",
                        principalColumn: "id_materie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificativ_Student_Studentiid_student",
                        column: x => x.Studentiid_student,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    id_administrator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_utilizator = table.Column<int>(type: "int", nullable: false),
                    Utilizatoriid_utilizator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.id_administrator);
                    table.ForeignKey(
                        name: "FK_Administrator_Utilizator_Utilizatoriid_utilizator",
                        column: x => x.Utilizatoriid_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id_utilizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    id_profesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salariu = table.Column<decimal>(type: "money", nullable: false),
                    grad = table.Column<int>(type: "int", nullable: true),
                    id_utilizator = table.Column<int>(type: "int", nullable: false),
                    Utilizatoriid_utilizator = table.Column<int>(type: "int", nullable: true),
                    id_materie = table.Column<int>(type: "int", nullable: false),
                    Materiiid_materie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.id_profesor);
                    table.ForeignKey(
                        name: "FK_Profesor_Materie_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materie",
                        principalColumn: "id_materie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesor_Utilizator_Utilizatoriid_utilizator",
                        column: x => x.Utilizatoriid_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id_utilizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_Utilizatoriid_utilizator",
                table: "Administrator",
                column: "Utilizatoriid_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Calificativ_Materiiid_materie",
                table: "Calificativ",
                column: "Materiiid_materie");

            migrationBuilder.CreateIndex(
                name: "IX_Calificativ_Studentiid_student",
                table: "Calificativ",
                column: "Studentiid_student");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Materiiid_materie",
                table: "Profesor",
                column: "Materiiid_materie");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Utilizatoriid_utilizator",
                table: "Profesor",
                column: "Utilizatoriid_utilizator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Calificativ");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
