using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Specializariid_Specializare",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Specializariid_Specializare",
                table: "Student",
                column: "Specializariid_Specializare");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Specializare_Specializariid_Specializare",
                table: "Student",
                column: "Specializariid_Specializare",
                principalTable: "Specializare",
                principalColumn: "id_Specializare",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Specializare_Specializariid_Specializare",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_Specializariid_Specializare",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Specializariid_Specializare",
                table: "Student");
        }
    }
}
