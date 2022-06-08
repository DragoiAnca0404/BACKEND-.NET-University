using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class AddforeignkeyforthetablecalledMaterii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Studentiid_student",
                table: "Materii",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_student",
                table: "Materii",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materii_Studentiid_student",
                table: "Materii",
                column: "Studentiid_student");

            migrationBuilder.AddForeignKey(
                name: "FK_Materii_Studenti_Studentiid_student",
                table: "Materii",
                column: "Studentiid_student",
                principalTable: "Studenti",
                principalColumn: "id_student",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materii_Studenti_Studentiid_student",
                table: "Materii");

            migrationBuilder.DropIndex(
                name: "IX_Materii_Studentiid_student",
                table: "Materii");

            migrationBuilder.DropColumn(
                name: "Studentiid_student",
                table: "Materii");

            migrationBuilder.DropColumn(
                name: "id_student",
                table: "Materii");
        }
    }
}
