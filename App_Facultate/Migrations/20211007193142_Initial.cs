using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materii",
                columns: table => new
                {
                    id_materie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_materie = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materii", x => x.id_materie);
                });

            migrationBuilder.CreateTable(
                name: "Specializari",
                columns: table => new
                {
                    id_Specializare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_specializare = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializari", x => x.id_Specializare);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
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
                    table.PrimaryKey("PK_Utilizatori", x => x.id_utilizator);
                });

            migrationBuilder.CreateTable(
                name: "Administratori",
                columns: table => new
                {
                    id_administrator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_utilizator = table.Column<int>(type: "int", nullable: false),
                    Utilizatoriid_utilizator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.id_administrator);
                    table.ForeignKey(
                        name: "FK_Administratori_Utilizatori_Utilizatoriid_utilizator",
                        column: x => x.Utilizatoriid_utilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "id_utilizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesori",
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
                    table.PrimaryKey("PK_Profesori", x => x.id_profesor);
                    table.ForeignKey(
                        name: "FK_Profesori_Materii_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materii",
                        principalColumn: "id_materie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesori_Utilizatori_Utilizatoriid_utilizator",
                        column: x => x.Utilizatoriid_utilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "id_utilizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scutit_plata = table.Column<bool>(type: "bit", nullable: false),
                    id_specializare = table.Column<int>(type: "int", nullable: false),
                    Specializariid_Specializare = table.Column<int>(type: "int", nullable: true),
                    id_utilizatori = table.Column<int>(type: "int", nullable: false),
                    Utilizatoriid_utilizator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.id_student);
                    table.ForeignKey(
                        name: "FK_Studenti_Specializari_Specializariid_Specializare",
                        column: x => x.Specializariid_Specializare,
                        principalTable: "Specializari",
                        principalColumn: "id_Specializare",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studenti_Utilizatori_Utilizatoriid_utilizator",
                        column: x => x.Utilizatoriid_utilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "id_utilizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificative",
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
                    table.PrimaryKey("PK_Calificative", x => x.id_Specializare);
                    table.ForeignKey(
                        name: "FK_Calificative_Materii_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materii",
                        principalColumn: "id_materie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificative_Studenti_Studentiid_student",
                        column: x => x.Studentiid_student,
                        principalTable: "Studenti",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_Utilizatoriid_utilizator",
                table: "Administratori",
                column: "Utilizatoriid_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Calificative_Materiiid_materie",
                table: "Calificative",
                column: "Materiiid_materie");

            migrationBuilder.CreateIndex(
                name: "IX_Calificative_Studentiid_student",
                table: "Calificative",
                column: "Studentiid_student");

            migrationBuilder.CreateIndex(
                name: "IX_Profesori_Materiiid_materie",
                table: "Profesori",
                column: "Materiiid_materie");

            migrationBuilder.CreateIndex(
                name: "IX_Profesori_Utilizatoriid_utilizator",
                table: "Profesori",
                column: "Utilizatoriid_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Specializariid_Specializare",
                table: "Studenti",
                column: "Specializariid_Specializare");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Utilizatoriid_utilizator",
                table: "Studenti",
                column: "Utilizatoriid_utilizator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "Calificative");

            migrationBuilder.DropTable(
                name: "Profesori");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Materii");

            migrationBuilder.DropTable(
                name: "Specializari");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
