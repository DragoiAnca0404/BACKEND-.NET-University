using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class AddSchemaDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Utilizator_Utilizatoriid_utilizator",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificativ_Materie_Materiiid_materie",
                table: "Calificativ");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificativ_Student_Studentiid_student",
                table: "Calificativ");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Materie_Materiiid_materie",
                table: "Profesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Utilizator_Utilizatoriid_utilizator",
                table: "Profesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Specializare_Specializariid_Specializare",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializare",
                table: "Specializare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materie",
                table: "Materie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificativ",
                table: "Calificativ");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrator",
                table: "Administrator");

            migrationBuilder.RenameTable(
                name: "Utilizator",
                newName: "Utilizatori");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Studenti");

            migrationBuilder.RenameTable(
                name: "Specializare",
                newName: "Specializari");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesori");

            migrationBuilder.RenameTable(
                name: "Materie",
                newName: "Materii");

            migrationBuilder.RenameTable(
                name: "Calificativ",
                newName: "Calificative");

            migrationBuilder.RenameTable(
                name: "Administrator",
                newName: "Administratori");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Specializariid_Specializare",
                table: "Studenti",
                newName: "IX_Studenti_Specializariid_Specializare");

            migrationBuilder.RenameIndex(
                name: "IX_Profesor_Utilizatoriid_utilizator",
                table: "Profesori",
                newName: "IX_Profesori_Utilizatoriid_utilizator");

            migrationBuilder.RenameIndex(
                name: "IX_Profesor_Materiiid_materie",
                table: "Profesori",
                newName: "IX_Profesori_Materiiid_materie");

            migrationBuilder.RenameIndex(
                name: "IX_Calificativ_Studentiid_student",
                table: "Calificative",
                newName: "IX_Calificative_Studentiid_student");

            migrationBuilder.RenameIndex(
                name: "IX_Calificativ_Materiiid_materie",
                table: "Calificative",
                newName: "IX_Calificative_Materiiid_materie");

            migrationBuilder.RenameIndex(
                name: "IX_Administrator_Utilizatoriid_utilizator",
                table: "Administratori",
                newName: "IX_Administratori_Utilizatoriid_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizatori",
                table: "Utilizatori",
                column: "id_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti",
                column: "id_student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializari",
                table: "Specializari",
                column: "id_Specializare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesori",
                table: "Profesori",
                column: "id_profesor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materii",
                table: "Materii",
                column: "id_materie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificative",
                table: "Calificative",
                column: "id_Specializare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administratori",
                table: "Administratori",
                column: "id_administrator");

            migrationBuilder.AddForeignKey(
                name: "FK_Administratori_Utilizatori_Utilizatoriid_utilizator",
                table: "Administratori",
                column: "Utilizatoriid_utilizator",
                principalTable: "Utilizatori",
                principalColumn: "id_utilizator",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificative_Materii_Materiiid_materie",
                table: "Calificative",
                column: "Materiiid_materie",
                principalTable: "Materii",
                principalColumn: "id_materie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificative_Studenti_Studentiid_student",
                table: "Calificative",
                column: "Studentiid_student",
                principalTable: "Studenti",
                principalColumn: "id_student",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesori_Materii_Materiiid_materie",
                table: "Profesori",
                column: "Materiiid_materie",
                principalTable: "Materii",
                principalColumn: "id_materie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesori_Utilizatori_Utilizatoriid_utilizator",
                table: "Profesori",
                column: "Utilizatoriid_utilizator",
                principalTable: "Utilizatori",
                principalColumn: "id_utilizator",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Specializari_Specializariid_Specializare",
                table: "Studenti",
                column: "Specializariid_Specializare",
                principalTable: "Specializari",
                principalColumn: "id_Specializare",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administratori_Utilizatori_Utilizatoriid_utilizator",
                table: "Administratori");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificative_Materii_Materiiid_materie",
                table: "Calificative");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificative_Studenti_Studentiid_student",
                table: "Calificative");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesori_Materii_Materiiid_materie",
                table: "Profesori");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesori_Utilizatori_Utilizatoriid_utilizator",
                table: "Profesori");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Specializari_Specializariid_Specializare",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizatori",
                table: "Utilizatori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializari",
                table: "Specializari");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesori",
                table: "Profesori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materii",
                table: "Materii");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificative",
                table: "Calificative");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administratori",
                table: "Administratori");

            migrationBuilder.RenameTable(
                name: "Utilizatori",
                newName: "Utilizator");

            migrationBuilder.RenameTable(
                name: "Studenti",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Specializari",
                newName: "Specializare");

            migrationBuilder.RenameTable(
                name: "Profesori",
                newName: "Profesor");

            migrationBuilder.RenameTable(
                name: "Materii",
                newName: "Materie");

            migrationBuilder.RenameTable(
                name: "Calificative",
                newName: "Calificativ");

            migrationBuilder.RenameTable(
                name: "Administratori",
                newName: "Administrator");

            migrationBuilder.RenameIndex(
                name: "IX_Studenti_Specializariid_Specializare",
                table: "Student",
                newName: "IX_Student_Specializariid_Specializare");

            migrationBuilder.RenameIndex(
                name: "IX_Profesori_Utilizatoriid_utilizator",
                table: "Profesor",
                newName: "IX_Profesor_Utilizatoriid_utilizator");

            migrationBuilder.RenameIndex(
                name: "IX_Profesori_Materiiid_materie",
                table: "Profesor",
                newName: "IX_Profesor_Materiiid_materie");

            migrationBuilder.RenameIndex(
                name: "IX_Calificative_Studentiid_student",
                table: "Calificativ",
                newName: "IX_Calificativ_Studentiid_student");

            migrationBuilder.RenameIndex(
                name: "IX_Calificative_Materiiid_materie",
                table: "Calificativ",
                newName: "IX_Calificativ_Materiiid_materie");

            migrationBuilder.RenameIndex(
                name: "IX_Administratori_Utilizatoriid_utilizator",
                table: "Administrator",
                newName: "IX_Administrator_Utilizatoriid_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator",
                column: "id_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "id_student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializare",
                table: "Specializare",
                column: "id_Specializare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "id_profesor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materie",
                table: "Materie",
                column: "id_materie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificativ",
                table: "Calificativ",
                column: "id_Specializare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrator",
                table: "Administrator",
                column: "id_administrator");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Utilizator_Utilizatoriid_utilizator",
                table: "Administrator",
                column: "Utilizatoriid_utilizator",
                principalTable: "Utilizator",
                principalColumn: "id_utilizator",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificativ_Materie_Materiiid_materie",
                table: "Calificativ",
                column: "Materiiid_materie",
                principalTable: "Materie",
                principalColumn: "id_materie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificativ_Student_Studentiid_student",
                table: "Calificativ",
                column: "Studentiid_student",
                principalTable: "Student",
                principalColumn: "id_student",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Materie_Materiiid_materie",
                table: "Profesor",
                column: "Materiiid_materie",
                principalTable: "Materie",
                principalColumn: "id_materie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Utilizator_Utilizatoriid_utilizator",
                table: "Profesor",
                column: "Utilizatoriid_utilizator",
                principalTable: "Utilizator",
                principalColumn: "id_utilizator",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Specializare_Specializariid_Specializare",
                table: "Student",
                column: "Specializariid_Specializare",
                principalTable: "Specializare",
                principalColumn: "id_Specializare",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
