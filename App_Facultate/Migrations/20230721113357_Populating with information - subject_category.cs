using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Facultate.Migrations
{
    public partial class Populatingwithinformationsubject_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "subject_category",
                columns: new[] { "id_subject_category", "Category_Jobsid_category_job", "Materiiid_materie", "id_category_job", "id_materie" },
                values: new object[,]
                {
                    { 1, null, null, 4, 9 },
                    { 2, null, null, 2, 9 },
                    { 3, null, null, 3, 10 },
                    { 4, null, null, 1, 11 },
                    { 5, null, null, 2, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "subject_category",
                keyColumn: "id_subject_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subject_category",
                keyColumn: "id_subject_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "subject_category",
                keyColumn: "id_subject_category",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "subject_category",
                keyColumn: "id_subject_category",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "subject_category",
                keyColumn: "id_subject_category",
                keyValue: 5);
        }
    }
}
