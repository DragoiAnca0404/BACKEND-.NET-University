using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class InsertnewrecordsOrarMonday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 1,
                columns: new[] { "Time_end", "Time_start", "ziua" },
                values: new object[] { "09:50", "08:00", 0 });

            migrationBuilder.InsertData(
                table: "Orar",
                columns: new[] { "id_orar", "Materiiid_materie", "Time_end", "Time_start", "id_materie", "ziua" },
                values: new object[,]
                {
                    { 2, null, "11:50", "10:00", 1, 0 },
                    { 3, null, "13:50", "12:00", 1, 0 },
                    { 4, null, "15:50", "14:00", 1, 0 },
                    { 5, null, "17:50", "16:00", 1, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Orar",
                keyColumn: "id_orar",
                keyValue: 1,
                columns: new[] { "Time_end", "Time_start", "ziua" },
                values: new object[] { "11:00", "11:00", 4 });
        }
    }
}
