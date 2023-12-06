using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_Jobs",
                columns: table => new
                {
                    id_category_job = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_categorie_job = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    quality = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    descriere_job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    atributii_job = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Job_qualities",
                columns: table => new
                {
                    id_job_quality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quality = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_category_job = table.Column<int>(type: "int", nullable: false),
                    Category_Jobsid_category_job = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_qualities", x => x.id_job_quality);
                    table.ForeignKey(
                        name: "FK_Job_qualities_Category_Jobs_Category_Jobsid_category_job",
                        column: x => x.Category_Jobsid_category_job,
                        principalTable: "Category_Jobs",
                        principalColumn: "id_category_job",
                        onDelete: ReferentialAction.Restrict);
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
                    { 13, "04-04-2023", null, null, 11, 5, 4.7999999999999998 },
                    { 12, "15-05-2023", null, null, 11, 5, 7.7999999999999998 },
                    { 11, "30-04-2023", null, null, 11, 5, 9.5 },
                    { 10, "20-06-2023", null, null, 10, 5, 5.0999999999999996 },
                    { 9, "14-06-2023", null, null, 10, 5, 8.5 },
                    { 8, "17-07-2023", null, null, 9, 5, 6.5 },
                    { 7, "10-10-2023", null, null, 9, 5, 7.0 },
                    { 6, "8-12-2023", null, null, 9, 5, 9.8000000000000007 },
                    { 5, "10-12-2023", null, null, 2, 4, 5.0 },
                    { 4, "10-12-2023", null, null, 1, 3, 10.0 },
                    { 3, "10-12-2023", null, null, 2, 3, 8.5500000000000007 },
                    { 1, "10-12-2023", null, null, 1, 1, 10.0 },
                    { 2, "10-12-2023", null, null, 2, 2, 9.0500000000000007 }
                });

            migrationBuilder.InsertData(
                table: "Category_Jobs",
                columns: new[] { "id_category_job", "atributii_job", "denumire_categorie_job", "descriere_job", "quality" },
                values: new object[,]
                {
                    { 1, "Analiza Cerințelor: Înțelegerea detaliată a cerințelor utilizatorilor și a contextului în care va fi utilizat software-ul.\r\n\r\nProiectarea: Crearea unui plan sau unui design al arhitecturii și a funcționalităților software-ului.\r\n\r\nProgramare: Scrierea codului sursă folosind diverse limbaje de programare și tehnologii.\r\n\r\nTestare: Verificarea și validarea software-ului pentru a identifica erori și asigura funcționarea corectă.\r\n\r\nDebugging: Identificarea și corectarea erorilor și a problemelor de cod. ", "Software Development", "Dezvoltarea software implică creația, proiectarea și menținerea aplicațiilor și programelor informatice. Acest proces se referă la transformarea cerințelor și nevoilor utilizatorilor în soluții tehnice funcționale și utile. Iată o privire de ansamblu asupra dezvoltării software și ce presupune:\r\n\r\n ", "Writing and communication, Statistical knowledge, Problem-solving skills, Programming Languages, Team player, Algorithm and Data Structures" },
                    { 2, "Limbaje de programare: Stăpânește cel puțin un limbaj de programare folosit în dezvoltarea backend, cum ar fi Python, Java, PHP, Ruby, Node.js, Go, etc.\r\n\r\nBaze de date: Înțelege conceptele bazelor de date și cunoaște SQL pentru a manipula și stoca datele în mod eficient.\r\n\r\nAPI-uri: Învățați să creați și să gestionați API-uri (Application Programming Interfaces) pentru a permite comunicația între frontend și backend.\r\n\r\nFramework-uri: Folosește cadre de lucru backend precum Django (Python), Ruby on Rails (Ruby), Spring (Java), Express.js (Node.js) pentru a dezvolta rapid și eficient. ", "Backend DEVELOPER", "Un dezvoltator de backend este responsabil pentru partea din spate a unei aplicații, care gestionează logica, stocarea datelor și comunicarea cu serverul. Pentru a deveni un dezvoltator de backend, trebuie să înveți următoarele:\r\n\r\n ", "Writing and communication, Familiarity with Servers, Problem-solving skills, Team player, Knowledge of APIs" },
                    { 3, "HTML: Înțelegerea structurii paginilor web folosind limbajul de marcă HTML pentru a defini elementele.\r\n\r\nCSS: Cunoașterea stilurilor de formatare și design folosind CSS pentru a da aspectul dorit paginilor web.\r\n\r\nJavaScript: Învățarea limbajului de programare JavaScript pentru adăugarea de interactivitate și funcționalități la paginile web.\r\n\r\nResponsive Design: Abilitatea de a crea pagini web care se adaptează la diferite dimensiuni de ecran (dispozitive desktop, tablete, telefoane mobile).\r\n\r\nFramework-uri Frontend: Cunoașterea unor cadre de lucru precum React, Angular sau Vue.js pentru dezvoltarea mai eficientă și organizată a interfețelor.\r\n\r\nVersion Control/Git: Înțelegerea sistemelor de control al versiunilor, cum ar fi Git, pentru colaborare și gestionarea eficientă a codului. ", "Frontend DEVELOPER", "Un dezvoltator de frontend este responsabil pentru crearea și implementarea componentelor vizuale ale unei aplicații web sau mobile.Pentru a deveni un dezvoltator de frontend, trebuie să înveți următoarele:\r\n\r\n", "Writing and communication,UI/UX Design Skills, Problem-solving skills, Gândire analitică, Javascript, CSS, HTML, Framework" },
                    { 4, "Analizezi datele folosind statistici și matematică.\r\nProgramezi, în special în limbaje precum Python sau R.\r\nLucrezi cu baze de date și cunoști limbajul SQL.\r\nCreezi vizualizări pentru a prezenta rezultatele.\r\nFolosești instrumente precum Excel, Pandas, NumPy pentru analiză.\r\nÎnțelegi conceptele statistice de bază.", "Data Analyst", "În mod succint, un analist de date colectează, analizează și interpretează date pentru a oferi informații valoroase în procesul decizional al unei organizații. Pentru a deveni un astfel de profesionist, trebuie să înveți să:\r\n\r\n", "Writing and communication, Statistical knowledge, Problem-solving skills, Creating dashboards and reports" }
                });

            migrationBuilder.InsertData(
                table: "Job_qualities",
                columns: new[] { "id_job_quality", "Category_Jobsid_category_job", "id_category_job", "quality" },
                values: new object[,]
                {
                    { 12, null, 2, "Familiarity with Servers" },
                    { 45, null, 4, "Creating dashboards and reports" },
                    { 35, null, 4, "Problem-solving skills" },
                    { 25, null, 4, "Statistical knowledge" },
                    { 15, null, 4, "Writing and communication" },
                    { 47, null, 3, "JavaScript" },
                    { 33, null, 3, "Frameworks and Libraries" },
                    { 23, null, 3, "CSS" },
                    { 13, null, 3, "HTML" },
                    { 43, null, 2, "Knowledge of APIs" },
                    { 32, null, 2, "Problem-solving skills" },
                    { 22, null, 2, "Team player" },
                    { 4, null, 1, "Organizat" },
                    { 3, null, 1, "Problem-solving skills" },
                    { 42, null, 2, "Organizat" },
                    { 1, null, 1, "Gândire analitică" },
                    { 2, null, 1, "Team player" }
                });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "Studentiid_student", "denumire_materie", "id_student" },
                values: new object[,]
                {
                    { 11, null, "Programare orientata obiect - Java", 5 },
                    { 10, null, "Dezvoltarea aplicatiilor Web", 5 },
                    { 9, null, "Sisteme de gestiune a bazelor de date", 5 },
                    { 8, null, "Psihologie politica", 1 },
                    { 6, null, "Psihologie politica", 3 },
                    { 5, null, "Psihologie sociala", 4 },
                    { 4, null, "Tehnici promotionale", 3 }
                });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "Studentiid_student", "denumire_materie", "id_student" },
                values: new object[,]
                {
                    { 3, null, "Bazele administratiei publice", 3 },
                    { 2, null, "Psihologie politica", 2 },
                    { 1, null, "Statistica economica", 1 },
                    { 7, null, "Psihologie politica", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orar",
                columns: new[] { "id_orar", "Materiiid_materie", "Time_end", "Time_start", "id_materie", "ziua" },
                values: new object[,]
                {
                    { 3, null, "13:50", "12:00", 1, 0 },
                    { 5, null, "17:50", "16:00", 1, 0 },
                    { 4, null, "15:50", "14:00", 1, 0 },
                    { 2, null, "11:50", "10:00", 1, 0 },
                    { 1, null, "09:50", "08:00", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Profesori",
                columns: new[] { "id_profesor", "Materiiid_materie", "Utilizatoriid_utilizator", "grad", "id_materie", "id_utilizator", "salariu" },
                values: new object[,]
                {
                    { 2, null, null, 1, 2, 4, 5800m },
                    { 1, null, null, 0, 1, 3, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Specializari",
                columns: new[] { "id_Specializare", "denumire_specializare" },
                values: new object[,]
                {
                    { 6, "Computer science" },
                    { 5, "Asistenta sociala" },
                    { 4, "Marketing" },
                    { 3, "Drept administrativ" },
                    { 2, "Stiinte politice" },
                    { 1, "Finante" }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "id_student", "Specializariid_Specializare", "Utilizatoriid_utilizator", "id_specializare", "id_utilizator", "scutit_plata" },
                values: new object[,]
                {
                    { 3, null, null, 3, 6, false },
                    { 2, null, null, 2, 2, false },
                    { 5, null, null, 6, 8, true },
                    { 4, null, null, 4, 7, true },
                    { 1, null, null, 1, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[,]
                {
                    { 7, "pop_ana1999@yahoo.com", "Pop", "pop1112", "Ana", "PopAna" },
                    { 6, "ionescu_denis@gmail.com", "Ionescu", "boboc12345", "Denis", "IonescuDenis" },
                    { 5, "anastasia_sia@yahoo.ro", "Soare", "sia73737*", "Anastasia", "AnastasiaS" },
                    { 4, "flo_andrei@yahoo.com", "Florescu", "moviehsjjs", "Andrei", "FlorescuAndrei" },
                    { 3, "george_07@gmail.com", "Ciobanu", "dogiuaaj922", "George", "George0647" },
                    { 2, "ana_maria@yahoo.com", "Ion", "ana827272", "Ana-Maria", "AnaMaria" },
                    { 1, "matei_matt@yahoo.ro", "Solomon", "matte777*", "Matei", "MateiSolomon" },
                    { 8, "toma_mihai@yahoo.com", "Toma", "tom1112$", "Mihai", "TomaMihai" }
                });

            migrationBuilder.InsertData(
                table: "subject_category",
                columns: new[] { "id_subject_category", "Category_Jobsid_category_job", "Materiiid_materie", "id_category_job", "id_materie" },
                values: new object[,]
                {
                    { 4, null, null, 1, 11 },
                    { 1, null, null, 4, 9 },
                    { 2, null, null, 2, 9 },
                    { 3, null, null, 3, 10 },
                    { 5, null, null, 2, 10 }
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
                name: "IX_Job_qualities_Category_Jobsid_category_job",
                table: "Job_qualities",
                column: "Category_Jobsid_category_job");

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
                name: "Job_qualities");

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
