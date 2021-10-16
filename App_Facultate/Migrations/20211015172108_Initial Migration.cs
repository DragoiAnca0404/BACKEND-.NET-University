using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class InitialMigration : Migration
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
                    id_utilizator = table.Column<int>(type: "int", nullable: false),
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
                    nota = table.Column<double>(type: "float", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Administratori",
                columns: new[] { "id_administrator", "Utilizatoriid_utilizator", "id_utilizator" },
                values: new object[] { 1, null, 5 });

            migrationBuilder.InsertData(
                table: "Calificative",
                columns: new[] { "id_Specializare", "Materiiid_materie", "Studentiid_student", "id_materie", "id_student", "nota" },
                values: new object[,]
                {
                    { 2, null, null, 2, 2, 9.0500000000000007 },
                    { 1, null, null, 1, 1, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "denumire_materie" },
                values: new object[,]
                {
                    { 5, "Psihologie sociala" },
                    { 4, "Tehnici promotionale" },
                    { 3, "Bazele administratiei publice" },
                    { 2, "Psihologie politica" },
                    { 1, "Statistica economica" }
                });

            migrationBuilder.InsertData(
                table: "Profesori",
                columns: new[] { "id_profesor", "Materiiid_materie", "Utilizatoriid_utilizator", "grad", "id_materie", "id_utilizator", "salariu" },
                values: new object[,]
                {
                    { 1, null, null, 0, 1, 3, 5000m },
                    { 2, null, null, 1, 2, 4, 5800m }
                });

            migrationBuilder.InsertData(
                table: "Specializari",
                columns: new[] { "id_Specializare", "denumire_specializare" },
                values: new object[,]
                {
                    { 4, "Marketing" },
                    { 1, "Finante" },
                    { 2, "Stiinte politice" },
                    { 3, "Drept administrativ" },
                    { 5, "Asistenta sociala" }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "id_student", "Specializariid_Specializare", "Utilizatoriid_utilizator", "id_specializare", "id_utilizator", "scutit_plata" },
                values: new object[,]
                {
                    { 2, null, null, 2, 2, false },
                    { 1, null, null, 1, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[,]
                {
                    { 4, "flo_andrei@yahoo.com", "Florescu", "moviehsjjs", "Andrei", "FlorescuAndrei" },
                    { 3, "george_07@gmail.com", "Ciobanu", "dogiuaaj922", "George", "George0647" },
                    { 2, "ana_maria@yahoo.com", "Ion", "ana827272", "Ana-Maria", "AnaMaria" },
                    { 1, "matei_matt@yahoo.ro", "Solomon", "matte777*", "Matei", "MateiSolomon" },
                    { 5, "anastasia_sia@yahoo.ro", "Soare", "sia73737*", "Anastasia", "AnastasiaS" }
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
