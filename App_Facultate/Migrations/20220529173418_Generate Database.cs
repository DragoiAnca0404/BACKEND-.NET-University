using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class GenerateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_Specializare",
                table: "Calificative",
                newName: "id_Calificativ");

            migrationBuilder.InsertData(
                table: "Calificative",
                columns: new[] { "id_Calificativ", "Materiiid_materie", "Studentiid_student", "id_materie", "id_student", "nota" },
                values: new object[,]
                {
                    { 3, null, null, 2, 3, 8.5500000000000007 },
                    { 4, null, null, 1, 3, 10.0 },
                    { 5, null, null, 2, 4, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "id_student", "Specializariid_Specializare", "Utilizatoriid_utilizator", "id_specializare", "id_utilizator", "scutit_plata" },
                values: new object[,]
                {
                    { 3, null, null, 3, 6, false },
                    { 4, null, null, 4, 7, true }
                });

            migrationBuilder.InsertData(
                table: "Utilizatori",
                columns: new[] { "id_utilizator", "email", "nume", "parola", "prenume", "username" },
                values: new object[,]
                {
                    { 6, "ionescu_denis@gmail.com", "Ionescu", "boboc12345", "Denis", "IonescuDenis" },
                    { 7, "pop_ana1999@yahoo.com", "Pop", "pop1112", "Ana", "PopAna" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calificative",
                keyColumn: "id_Calificativ",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "id_student",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilizatori",
                keyColumn: "id_utilizator",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "id_Calificativ",
                table: "Calificative",
                newName: "id_Specializare");
        }
    }
}
