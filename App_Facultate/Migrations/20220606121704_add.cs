using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    id_orar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ziua = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    orar_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orar_sfarsit = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Orar_Materiiid_materie",
                table: "Orar",
                column: "Materiiid_materie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orar");
        }
    }
}
