using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HistortyName",
                columns: new[] { "ID", "name" },
                values: new object[,]
                {
                    { 1, "إضافة معاملة" },
                    { 2, "تعديل معاملة" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name", "code", "state" },
                values: new object[,]
                {
                    { 1, "لوحة التحكم ", "dash", true },
                    { 2, "المستخدمين  ", "user", true },
                    { 3, "طباعة  ", "print", true },
                    { 4, "من طرف من  ", "who", true },
                    { 5, " التسليم ", "dil", true },
                    { 6, "الإضافة والتعديل  ", "add", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistortyName",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HistortyName",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 6);
        }
    }
}
