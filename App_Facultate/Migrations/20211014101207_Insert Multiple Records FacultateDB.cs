using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class InsertMultipleRecordsFacultateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 10);

            migrationBuilder.AlterColumn<double>(
                name: "nota",
                table: "Calificative",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Administratori",
                columns: new[] { "id_administrator", "Utilizatoriid_utilizator", "id_utilizator" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 },
                    { 4, null, 4 },
                    { 5, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Calificative",
                columns: new[] { "id_Specializare", "Materiiid_materie", "Studentiid_student", "id_materie", "id_student", "nota" },
                values: new object[,]
                {
                    { 5, null, null, 5, 5, 4.7999999999999998 },
                    { 4, null, null, 4, 4, 5.6500000000000004 },
                    { 2, null, null, 2, 2, 9.0500000000000007 },
                    { 1, null, null, 1, 1, 10.0 },
                    { 3, null, null, 3, 3, 7.5 }
                });

            migrationBuilder.InsertData(
                table: "Materii",
                columns: new[] { "id_materie", "denumire_materie" },
                values: new object[,]
                {
                    { 3, "Bazele administratiei publice" },
                    { 5, "Psihologie sociala" },
                    { 1, "Statistica economica" },
                    { 2, "Psihologie politica" },
                    { 4, "Tehnici promotionale" }
                });

            migrationBuilder.InsertData(
                table: "Profesori",
                columns: new[] { "id_profesor", "Materiiid_materie", "Utilizatoriid_utilizator", "grad", "id_materie", "id_utilizator", "salariu" },
                values: new object[,]
                {
                    { 5, null, null, 0, 0, 0, 0m },
                    { 4, null, null, 3, 0, 0, 0m },
                    { 3, null, null, 2, 0, 0, 0m },
                    { 2, null, null, 1, 0, 0, 0m },
                    { 1, null, null, 0, 0, 0, 0m }
                });

            migrationBuilder.InsertData(
                table: "Specializari",
                columns: new[] { "id_Specializare", "denumire_specializare" },
                values: new object[,]
                {
                    { 3, "Drept administrativ" },
                    { 2, "Stiinte politice" },
                    { 1, "Finante" },
                    { 5, "Asistenta sociala" },
                    { 4, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "id_student", "Specializariid_Specializare", "Utilizatoriid_utilizator", "id_specializare", "id_utilizatori", "scutit_plata" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, true },
                    { 2, null, null, 2, 2, false },
                    { 3, null, null, 3, 3, false },
                    { 4, null, null, 4, 4, true },
                    { 5, null, null, 5, 5, false }
                });

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[,]
                {
                    { 5, "anastasia_sia@yahoo.ro", "Soare", "sia73737*", "Anastasia", "AnastasiaS" },
                    { 4, "flo_andrei@yahoo.com", "Florescu", "moviehsjjs", "Andrei", "FlorescuAndrei" },
                    { 3, "george_07@gmail.com", "Ciobanu", "dogiuaaj922", "George", "George0647" },
                    { 2, "ana_maria@yahoo.com", "Ion", "ana827272", "Ana-Maria", "AnaMaria" },
                    { 1, "matei_matt@yahoo.ro", "Solomon", "matte777*", "Matei", "MateiSolomon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "id_administrator",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "id_administrator",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "id_administrator",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "id_administrator",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "id_administrator",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Specializare",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Specializare",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Specializare",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Specializare",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Specializare",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materii",
                keyColumn: "id_materie",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "id_profesor",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializari",
                keyColumn: "id_Specializare",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializari",
                keyColumn: "id_Specializare",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializari",
                keyColumn: "id_Specializare",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializari",
                keyColumn: "id_Specializare",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializari",
                keyColumn: "id_Specializare",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "nota",
                table: "Calificative",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[] { 10, "matei_matt@yahoo.ro", "Solomon", "matte777*", "Matei", "MateiSolomon" });
        }
    }
}
