using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Populatingwithinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_Jobs",
                columns: table => new
                {
                    id_category_job = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_categorie_job = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Jobs", x => x.id_category_job);
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
                name: "Jobs",
                columns: table => new
                {
                    id_job = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_job = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_category_job = table.Column<int>(type: "int", nullable: false),
                    Category_Jobsid_category_job = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id_job);
                    table.ForeignKey(
                        name: "FK_Jobs_Category_Jobs_Category_Jobsid_category_job",
                        column: x => x.Category_Jobsid_category_job,
                        principalTable: "Category_Jobs",
                        principalColumn: "id_category_job",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Materii",
                columns: table => new
                {
                    id_materie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_materie = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    Studentiid_student = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materii", x => x.id_materie);
                    table.ForeignKey(
                        name: "FK_Materii_Studenti_Studentiid_student",
                        column: x => x.Studentiid_student,
                        principalTable: "Studenti",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificative",
                columns: table => new
                {
                    id_Calificativ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<double>(type: "float", nullable: false),
                    CurrentDateGrade = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_materie = table.Column<int>(type: "int", nullable: false),
                    Materiiid_materie = table.Column<int>(type: "int", nullable: true),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    Studentiid_student = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificative", x => x.id_Calificativ);
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

            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    id_orar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ziua = table.Column<int>(type: "int", nullable: true),
                    Time_start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_end = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_materie = table.Column<int>(type: "int", nullable: false),
                    Materiiid_materie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orar", x => x.id_orar);
                    table.ForeignKey(
                        name: "FK_Orar_Materii_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materii",
                        principalColumn: "id_materie",
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
                name: "subject_category",
                columns: table => new
                {
                    id_subject_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_materie = table.Column<int>(type: "int", nullable: false),
                    Materiiid_materie = table.Column<int>(type: "int", nullable: true),
                    id_category_job = table.Column<int>(type: "int", nullable: false),
                    Category_Jobsid_category_job = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_category", x => x.id_subject_category);
                    table.ForeignKey(
                        name: "FK_subject_category_Category_Jobs_Category_Jobsid_category_job",
                        column: x => x.Category_Jobsid_category_job,
                        principalTable: "Category_Jobs",
                        principalColumn: "id_category_job",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subject_category_Materii_Materiiid_materie",
                        column: x => x.Materiiid_materie,
                        principalTable: "Materii",
                        principalColumn: "id_materie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Administratori",
                columns: new[] { "id_administrator", "Utilizatoriid_utilizator", "id_utilizator" },
                values: new object[] { 1, null, 5 });

            migrationBuilder.InsertData(
                table: "Calificative",
                columns: new[] { "id_Calificativ", "CurrentDateGrade", "Materiiid_materie", "Studentiid_student", "id_materie", "id_student", "nota" },
                values: new object[,]
                {
                    { 1, "10-12-2023", null, null, 1, 1, 10.0 },
                    { 4, "10-12-2023", null, null, 1, 3, 10.0 },
                    { 5, "10-12-2023", null, null, 2, 4, 5.0 },
                    { 6, "8-12-2023", null, null, 9, 5, 9.8000000000000007 },
                    { 7, "10-10-2023", null, null, 9, 5, 7.0 },
                    { 8, "17-07-2023", null, null, 9, 5, 6.5 },
                    { 2, "10-12-2023", null, null, 2, 2, 9.0500000000000007 },
                    { 9, "14-06-2023", null, null, 10, 5, 8.5 },
                    { 11, "30-04-2023", null, null, 11, 5, 9.5 },
                    { 12, "15-05-2023", null, null, 11, 5, 7.7999999999999998 },
                    { 13, "04-04-2023", null, null, 11, 5, 4.7999999999999998 },
                    { 10, "20-06-2023", null, null, 10, 5, 5.0999999999999996 },
                    { 3, "10-12-2023", null, null, 2, 3, 8.5500000000000007 }
                });

            migrationBuilder.InsertData(
                table: "Category_Jobs",
                columns: new[] { "id_category_job", "denumire_categorie_job" },
                values: new object[,]
                {
                    { 3, "Frontend DEVELOPER" },
                    { 2, "Backend DEVELOPER" },
                    { 1, "Software Development" },
                    { 4, "Data Analyst" }
                });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "Studentiid_student", "denumire_materie", "id_student" },
                values: new object[,]
                {
                    { 6, null, "Psihologie politica", 3 },
                    { 8, null, "Psihologie politica", 1 },
                    { 7, null, "Psihologie politica", 4 },
                    { 11, null, "Programare orientata obiect - Java", 5 },
                    { 5, null, "Psihologie sociala", 4 },
                    { 4, null, "Tehnici promotionale", 3 },
                    { 3, null, "Bazele administratiei publice", 3 },
                    { 2, null, "Psihologie politica", 2 },
                    { 1, null, "Statistica economica", 1 },
                    { 9, null, "Sisteme de gestiune a bazelor de date", 5 },
                    { 10, null, "Dezvoltarea aplicatiilor Web", 5 }
                });

            migrationBuilder.InsertData(
                table: "Orar",
                columns: new[] { "id_orar", "Materiiid_materie", "Time_end", "Time_start", "id_materie", "ziua" },
                values: new object[,]
                {
                    { 4, null, "15:50", "14:00", 1, 0 },
                    { 1, null, "09:50", "08:00", 1, 0 },
                    { 5, null, "17:50", "16:00", 1, 0 },
                    { 3, null, "13:50", "12:00", 1, 0 },
                    { 2, null, "11:50", "10:00", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Profesori",
                columns: new[] { "id_profesor", "Materiiid_materie", "Utilizatoriid_utilizator", "grad", "id_materie", "id_utilizator", "salariu" },
                values: new object[,]
                {
                    { 1, null, null, 0, 1, 3, 5000m },
                    { 2, null, null, 1, 2, 4, 5800m },
                    { 3, null, null, 3, 2, 4, 7800m }
                });

            migrationBuilder.InsertData(
                table: "Specializari",
                columns: new[] { "id_Specializare", "denumire_specializare" },
                values: new object[,]
                {
                    { 1, "Finante" },
                    { 2, "Stiinte politice" },
                    { 3, "Drept administrativ" },
                    { 4, "Marketing" },
                    { 6, "Computer science" }
                });

            migrationBuilder.InsertData(
                table: "Specializari",
                columns: new[] { "id_Specializare", "denumire_specializare" },
                values: new object[] { 5, "Asistenta sociala" });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "id_student", "Specializariid_Specializare", "Utilizatoriid_utilizator", "id_specializare", "id_utilizator", "scutit_plata" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, true },
                    { 2, null, null, 2, 2, false },
                    { 3, null, null, 3, 6, false },
                    { 4, null, null, 4, 7, true },
                    { 5, null, null, 6, 8, true }
                });

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[,]
                {
                    { 1, "matei_matt@yahoo.ro", "Solomon", "matte777*", "Matei", "MateiSolomon" },
                    { 2, "ana_maria@yahoo.com", "Ion", "ana827272", "Ana-Maria", "AnaMaria" },
                    { 3, "george_07@gmail.com", "Ciobanu", "dogiuaaj922", "George", "George0647" },
                    { 4, "flo_andrei@yahoo.com", "Florescu", "moviehsjjs", "Andrei", "FlorescuAndrei" },
                    { 5, "anastasia_sia@yahoo.ro", "Soare", "sia73737*", "Anastasia", "AnastasiaS" },
                    { 6, "ionescu_denis@gmail.com", "Ionescu", "boboc12345", "Denis", "IonescuDenis" },
                    { 8, "toma_mihai@yahoo.com", "Toma", "tom1112$", "Mihai", "TomaMihai" },
                    { 7, "pop_ana1999@yahoo.com", "Pop", "pop1112", "Ana", "PopAna" }
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
                name: "IX_Jobs_Category_Jobsid_category_job",
                table: "Jobs",
                column: "Category_Jobsid_category_job");

            migrationBuilder.CreateIndex(
                name: "IX_Materii_Studentiid_student",
                table: "Materii",
                column: "Studentiid_student");

            migrationBuilder.CreateIndex(
                name: "IX_Orar_Materiiid_materie",
                table: "Orar",
                column: "Materiiid_materie");

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

            migrationBuilder.CreateIndex(
                name: "IX_subject_category_Category_Jobsid_category_job",
                table: "subject_category",
                column: "Category_Jobsid_category_job");

            migrationBuilder.CreateIndex(
                name: "IX_subject_category_Materiiid_materie",
                table: "subject_category",
                column: "Materiiid_materie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "Calificative");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Orar");

            migrationBuilder.DropTable(
                name: "Profesori");

            migrationBuilder.DropTable(
                name: "subject_category");

            migrationBuilder.DropTable(
                name: "Category_Jobs");

            migrationBuilder.DropTable(
                name: "Materii");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Specializari");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
